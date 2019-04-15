namespace Kapec
{
    partial class ProxyBrowser
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
			this.WebBrowse = new System.Windows.Forms.WebBrowser();
			this.HTMLTB = new System.Windows.Forms.RichTextBox();
			this.AdressTextBox = new System.Windows.Forms.TextBox();
			this.GoHTML = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// WebBrowse
			// 
			this.WebBrowse.Location = new System.Drawing.Point(12, 38);
			this.WebBrowse.MinimumSize = new System.Drawing.Size(20, 20);
			this.WebBrowse.Name = "WebBrowse";
			this.WebBrowse.Size = new System.Drawing.Size(710, 519);
			this.WebBrowse.TabIndex = 10;
			this.WebBrowse.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowse_DocumentCompleted);
			// 
			// HTMLTB
			// 
			this.HTMLTB.Location = new System.Drawing.Point(728, 38);
			this.HTMLTB.Name = "HTMLTB";
			this.HTMLTB.Size = new System.Drawing.Size(283, 519);
			this.HTMLTB.TabIndex = 11;
			this.HTMLTB.Text = "";
			// 
			// AdressTextBox
			// 
			this.AdressTextBox.Location = new System.Drawing.Point(12, 12);
			this.AdressTextBox.Name = "AdressTextBox";
			this.AdressTextBox.Size = new System.Drawing.Size(710, 20);
			this.AdressTextBox.TabIndex = 12;
			// 
			// GoHTML
			// 
			this.GoHTML.Location = new System.Drawing.Point(728, 10);
			this.GoHTML.Name = "GoHTML";
			this.GoHTML.Size = new System.Drawing.Size(75, 23);
			this.GoHTML.TabIndex = 13;
			this.GoHTML.Text = "Go";
			this.GoHTML.UseVisualStyleBackColor = true;
			this.GoHTML.Click += new System.EventHandler(this.GoHTML_Click);
			// 
			// ProxyBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1014, 567);
			this.Controls.Add(this.GoHTML);
			this.Controls.Add(this.AdressTextBox);
			this.Controls.Add(this.HTMLTB);
			this.Controls.Add(this.WebBrowse);
			this.Name = "ProxyBrowser";
			this.Text = "ProxyBrowser";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser WebBrowse;
        private System.Windows.Forms.RichTextBox HTMLTB;
        private System.Windows.Forms.TextBox AdressTextBox;
        private System.Windows.Forms.Button GoHTML;
    }
}