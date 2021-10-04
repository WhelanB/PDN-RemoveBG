using Newtonsoft.Json;
using PaintDotNet;
using PaintDotNet.Effects;
using RemoveBackground.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveBackground
{
    [PluginSupportInfo(typeof(PluginSupportInfo))]
    public class RemoveBackgroundPlugin : Effect
    {

        internal static Bitmap Icon
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream iconStream = assembly.GetManifestResourceStream("RemoveBackground.Assets.icon.ico");
                Bitmap icon = new Bitmap(iconStream);
                return icon;
            }
        }

        private string key;

        public RemoveBackgroundPlugin()
            :base("Remove Background", Icon, "Tools", new EffectOptions { Flags = EffectFlags.SingleThreaded, RenderingSchedule = EffectRenderingSchedule.None })
        {
        }

        /// <summary>
        /// Read the API key from config.json, or prompt the user to enter their API key if config.json does not exist
        /// </summary>
        /// <returns>String containing the API key</returns>
        public string GetOrPromptApiKey()
        {
            using (InputDialog dialog = new InputDialog())
            {
                // Get path to config.json
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json";

                // If it exists, read the API key and return it
                if (File.Exists(configPath))
                {
                    Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
                    return config.ApiKey;
                }
                else
                {
                    // Otherwise, prompt the user for their API key
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string apiKey = dialog.apiKey;
                        Config config = new Config()
                        {
                            ApiKey = apiKey
                        };
                        File.WriteAllText(configPath, JsonConvert.SerializeObject(config));
                        return apiKey;
                    }
                    else
                    {
                        // If they cancel, return an empty string. An authorisation failed message will be shown 
                        return string.Empty;
                    }

                }
            }
        }

        protected override void OnSetRenderInfo(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            if (String.IsNullOrEmpty(key)) {
                key = GetOrPromptApiKey();
            }
            base.OnSetRenderInfo(parameters, dstArgs, srcArgs);
        }

        public static byte[] ToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public override void Render(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
        {
            // Create a cancellation token to interface with the PDN IsCancelRequested variable
            CancellationToken token = new CancellationToken(IsCancelRequested);
            // Clone the bitmap from srcArgs, create a HttpClient (cannot be singleton) and form data for image content
            using (Bitmap map = (Bitmap)srcArgs.Bitmap.Clone())
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {

                // Set headers and image content, then POST
                formData.Headers.Add("X-Api-Key", key);
                formData.Add(new ByteArrayContent(ToByteArray(map, ImageFormat.Png)), "image_file", "file.jpg");
                formData.Add(new StringContent("auto"), "size");
                HttpResponseMessage response;
                response = client.PostAsync("https://api.remove.bg/v1.0/removebg", formData, token).Result;
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // Grab the POST response, and scale it back to the original image dimension (only applies when free credits are used)
                        Stream responseStream = response.Content.ReadAsStreamAsync().Result;
                        Bitmap bitmap = new Bitmap(responseStream);
                        Bitmap destination = new Bitmap(bitmap, new Size(dstArgs.Bounds.Width, dstArgs.Bounds.Height));
                        bitmap.Dispose();
                        responseStream.Dispose();
                        dstArgs.Surface.CopyFromGdipBitmap(destination);
                        destination.Dispose();
                    }
                    catch (Exception e)
                    {
                        Task.Run(() => MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000));
                    }

                }
                else
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    ServiceErrorResponse serviceErrorResponse = JsonConvert.DeserializeObject<ServiceErrorResponse>(responseContent);
                    foreach (ServiceError error in serviceErrorResponse.Errors)
                    {
                        Task.Run(() => MessageBox.Show(error.Title, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000));
                    }
                }
            }
        }
    }
}
