using PaintDotNet;
using System;
using System.Reflection;

namespace RemoveBackground
{
    public class PluginSupportInfo : IPluginSupportInfo
    {
        private readonly Assembly assembly = typeof(PluginSupportInfo).Assembly;

        public string Author => this.assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

        public string Copyright => this.assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

        public string DisplayName => this.assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;

        public Version Version => this.assembly.GetName().Version;

        public Uri WebsiteUri => new Uri("https://github.com/WhelanB/PDN-RemoveBG");
    }
}
