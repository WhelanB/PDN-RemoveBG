namespace RemoveBackground
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            this.apiKeyInput = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.getApiKeyLabel = new System.Windows.Forms.LinkLabel();
            this.openConfigLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // apiKeyInput
            // 
            this.apiKeyInput.Location = new System.Drawing.Point(12, 31);
            this.apiKeyInput.Name = "apiKeyInput";
            this.apiKeyInput.Size = new System.Drawing.Size(358, 20);
            this.apiKeyInput.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(295, 57);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(214, 57);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter API Key:";
            // 
            // getApiKeyLabel
            // 
            this.getApiKeyLabel.AutoSize = true;
            this.getApiKeyLabel.Location = new System.Drawing.Point(12, 66);
            this.getApiKeyLabel.Name = "getApiKeyLabel";
            this.getApiKeyLabel.Size = new System.Drawing.Size(65, 13);
            this.getApiKeyLabel.TabIndex = 4;
            this.getApiKeyLabel.TabStop = true;
            this.getApiKeyLabel.Text = "Get API Key";
            this.getApiKeyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetApiKeyLabel_LinkClicked);
            // 
            // openConfigLabel
            // 
            this.openConfigLabel.AutoSize = true;
            this.openConfigLabel.Location = new System.Drawing.Point(83, 66);
            this.openConfigLabel.Name = "openConfigLabel";
            this.openConfigLabel.Size = new System.Drawing.Size(111, 13);
            this.openConfigLabel.TabIndex = 5;
            this.openConfigLabel.TabStop = true;
            this.openConfigLabel.Text = "Open Config Directory";
            this.openConfigLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenConfigLabel_LinkClicked);
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 89);
            this.Controls.Add(this.openConfigLabel);
            this.Controls.Add(this.getApiKeyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.apiKeyInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputDialog";
            this.Text = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox apiKeyInput;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel getApiKeyLabel;
        private System.Windows.Forms.LinkLabel openConfigLabel;
    }
}