namespace Kapec
{
    partial class FileConnectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileConnectForm));
            this.MyCopy = new System.Windows.Forms.Button();
            this.MyDelete = new System.Windows.Forms.Button();
            this.MyInsert = new System.Windows.Forms.Button();
            this.OtherInsert = new System.Windows.Forms.Button();
            this.OtherDelete = new System.Windows.Forms.Button();
            this.OtherCopy = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.ComboboxOfMyComp = new System.Windows.Forms.ComboBox();
            this.ComboboxOfOtherComp = new System.Windows.Forms.ComboBox();
            this.OtherStartDirectLoad = new System.Windows.Forms.Button();
            this.OtherFullDirectPole = new System.Windows.Forms.TextBox();
            this.GoZagruzitOtherDirect = new System.Windows.Forms.Button();
            this.GoNazadOtherDirect = new System.Windows.Forms.Button();
            this.OtherCompDirectBox = new System.Windows.Forms.ListView();
            this.OtherDitectIcons = new System.Windows.Forms.ImageList(this.components);
            this.MyFullDirectPole = new System.Windows.Forms.TextBox();
            this.GoNazadMyDirect = new System.Windows.Forms.Button();
            this.MyCompDirectBox = new System.Windows.Forms.ListView();
            this.MyStartDirectLoad = new System.Windows.Forms.Button();
            this.LoadMyDirect = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DownloadBufferScB = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UploadBufferScB = new System.Windows.Forms.HScrollBar();
            this.DownloadBufferTextBox = new System.Windows.Forms.TextBox();
            this.UploadBufferTextBox = new System.Windows.Forms.TextBox();
            this.ScrollBarUpload = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeUploadBuffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyCopy
            // 
            this.MyCopy.Location = new System.Drawing.Point(12, 387);
            this.MyCopy.Name = "MyCopy";
            this.MyCopy.Size = new System.Drawing.Size(60, 30);
            this.MyCopy.TabIndex = 6;
            this.MyCopy.Text = "Copy";
            this.MyCopy.UseVisualStyleBackColor = true;
            this.MyCopy.Click += new System.EventHandler(this.MyCopy_Click);
            // 
            // MyDelete
            // 
            this.MyDelete.Location = new System.Drawing.Point(144, 387);
            this.MyDelete.Name = "MyDelete";
            this.MyDelete.Size = new System.Drawing.Size(60, 30);
            this.MyDelete.TabIndex = 7;
            this.MyDelete.Text = "Delete";
            this.MyDelete.UseVisualStyleBackColor = true;
            this.MyDelete.Click += new System.EventHandler(this.MyDelete_Click);
            // 
            // MyInsert
            // 
            this.MyInsert.Location = new System.Drawing.Point(78, 387);
            this.MyInsert.Name = "MyInsert";
            this.MyInsert.Size = new System.Drawing.Size(60, 30);
            this.MyInsert.TabIndex = 8;
            this.MyInsert.Text = "Insert";
            this.MyInsert.UseVisualStyleBackColor = true;
            this.MyInsert.Click += new System.EventHandler(this.MyInsert_Click);
            // 
            // OtherInsert
            // 
            this.OtherInsert.Location = new System.Drawing.Point(1146, 387);
            this.OtherInsert.Name = "OtherInsert";
            this.OtherInsert.Size = new System.Drawing.Size(60, 30);
            this.OtherInsert.TabIndex = 11;
            this.OtherInsert.Text = "Insert";
            this.OtherInsert.UseVisualStyleBackColor = true;
            // 
            // OtherDelete
            // 
            this.OtherDelete.Location = new System.Drawing.Point(1212, 387);
            this.OtherDelete.Name = "OtherDelete";
            this.OtherDelete.Size = new System.Drawing.Size(60, 30);
            this.OtherDelete.TabIndex = 10;
            this.OtherDelete.Text = "Delete";
            this.OtherDelete.UseVisualStyleBackColor = true;
            // 
            // OtherCopy
            // 
            this.OtherCopy.Location = new System.Drawing.Point(1080, 387);
            this.OtherCopy.Name = "OtherCopy";
            this.OtherCopy.Size = new System.Drawing.Size(60, 30);
            this.OtherCopy.TabIndex = 9;
            this.OtherCopy.Text = "Copy";
            this.OtherCopy.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(532, 386);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 30);
            this.button9.TabIndex = 14;
            this.button9.Tag = "";
            this.button9.Text = "Reload";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(687, 387);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 30);
            this.button10.TabIndex = 15;
            this.button10.Tag = "";
            this.button10.Text = "Reload";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // ComboboxOfMyComp
            // 
            this.ComboboxOfMyComp.FormattingEnabled = true;
            this.ComboboxOfMyComp.Location = new System.Drawing.Point(12, 12);
            this.ComboboxOfMyComp.Name = "ComboboxOfMyComp";
            this.ComboboxOfMyComp.Size = new System.Drawing.Size(130, 21);
            this.ComboboxOfMyComp.TabIndex = 16;
            this.ComboboxOfMyComp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboboxOfMyComp_MouseClick);
            // 
            // ComboboxOfOtherComp
            // 
            this.ComboboxOfOtherComp.FormattingEnabled = true;
            this.ComboboxOfOtherComp.Location = new System.Drawing.Point(687, 10);
            this.ComboboxOfOtherComp.Name = "ComboboxOfOtherComp";
            this.ComboboxOfOtherComp.Size = new System.Drawing.Size(116, 21);
            this.ComboboxOfOtherComp.TabIndex = 17;
            this.ComboboxOfOtherComp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboboxOfOtherComp_MouseClick);
            // 
            // OtherStartDirectLoad
            // 
            this.OtherStartDirectLoad.Location = new System.Drawing.Point(809, 10);
            this.OtherStartDirectLoad.Name = "OtherStartDirectLoad";
            this.OtherStartDirectLoad.Size = new System.Drawing.Size(75, 23);
            this.OtherStartDirectLoad.TabIndex = 23;
            this.OtherStartDirectLoad.Text = "Load disk";
            this.OtherStartDirectLoad.UseVisualStyleBackColor = true;
            this.OtherStartDirectLoad.Click += new System.EventHandler(this.OtherStartDirectLoad_Click);
            // 
            // OtherFullDirectPole
            // 
            this.OtherFullDirectPole.Location = new System.Drawing.Point(936, 14);
            this.OtherFullDirectPole.Name = "OtherFullDirectPole";
            this.OtherFullDirectPole.Size = new System.Drawing.Size(255, 20);
            this.OtherFullDirectPole.TabIndex = 26;
            // 
            // GoZagruzitOtherDirect
            // 
            this.GoZagruzitOtherDirect.Location = new System.Drawing.Point(1197, 12);
            this.GoZagruzitOtherDirect.Name = "GoZagruzitOtherDirect";
            this.GoZagruzitOtherDirect.Size = new System.Drawing.Size(75, 23);
            this.GoZagruzitOtherDirect.TabIndex = 27;
            this.GoZagruzitOtherDirect.Text = "Load";
            this.GoZagruzitOtherDirect.UseVisualStyleBackColor = true;
            this.GoZagruzitOtherDirect.Click += new System.EventHandler(this.GoZagruzitDirect_Click);
            // 
            // GoNazadOtherDirect
            // 
            this.GoNazadOtherDirect.Location = new System.Drawing.Point(890, 10);
            this.GoNazadOtherDirect.Name = "GoNazadOtherDirect";
            this.GoNazadOtherDirect.Size = new System.Drawing.Size(40, 23);
            this.GoNazadOtherDirect.TabIndex = 28;
            this.GoNazadOtherDirect.Text = "<=";
            this.GoNazadOtherDirect.UseVisualStyleBackColor = true;
            this.GoNazadOtherDirect.Click += new System.EventHandler(this.GoNazadDirect_Click);
            // 
            // OtherCompDirectBox
            // 
            this.OtherCompDirectBox.LargeImageList = this.OtherDitectIcons;
            this.OtherCompDirectBox.Location = new System.Drawing.Point(687, 41);
            this.OtherCompDirectBox.MultiSelect = false;
            this.OtherCompDirectBox.Name = "OtherCompDirectBox";
            this.OtherCompDirectBox.Size = new System.Drawing.Size(585, 340);
            this.OtherCompDirectBox.TabIndex = 29;
            this.OtherCompDirectBox.UseCompatibleStateImageBehavior = false;
            this.OtherCompDirectBox.DoubleClick += new System.EventHandler(this.OtherCompDirectBox_DoubleClick);
            // 
            // OtherDitectIcons
            // 
            this.OtherDitectIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("OtherDitectIcons.ImageStream")));
            this.OtherDitectIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.OtherDitectIcons.Images.SetKeyName(0, "AudioIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(1, "EXEIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(2, "FileIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(3, "PapkaIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(4, "TextIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(5, "VideoIcon.png");
            this.OtherDitectIcons.Images.SetKeyName(6, "ImageIcon.png");
            // 
            // MyFullDirectPole
            // 
            this.MyFullDirectPole.Location = new System.Drawing.Point(284, 12);
            this.MyFullDirectPole.Name = "MyFullDirectPole";
            this.MyFullDirectPole.Size = new System.Drawing.Size(247, 20);
            this.MyFullDirectPole.TabIndex = 30;
            // 
            // GoNazadMyDirect
            // 
            this.GoNazadMyDirect.Location = new System.Drawing.Point(238, 11);
            this.GoNazadMyDirect.Name = "GoNazadMyDirect";
            this.GoNazadMyDirect.Size = new System.Drawing.Size(40, 23);
            this.GoNazadMyDirect.TabIndex = 31;
            this.GoNazadMyDirect.Text = "<=";
            this.GoNazadMyDirect.UseVisualStyleBackColor = true;
            this.GoNazadMyDirect.Click += new System.EventHandler(this.GoNazadMyDirect_Click);
            // 
            // MyCompDirectBox
            // 
            this.MyCompDirectBox.LargeImageList = this.OtherDitectIcons;
            this.MyCompDirectBox.Location = new System.Drawing.Point(12, 40);
            this.MyCompDirectBox.MultiSelect = false;
            this.MyCompDirectBox.Name = "MyCompDirectBox";
            this.MyCompDirectBox.Size = new System.Drawing.Size(580, 340);
            this.MyCompDirectBox.TabIndex = 32;
            this.MyCompDirectBox.UseCompatibleStateImageBehavior = false;
            this.MyCompDirectBox.DoubleClick += new System.EventHandler(this.MyCompDirectBox_DoubleClick);
            // 
            // MyStartDirectLoad
            // 
            this.MyStartDirectLoad.Location = new System.Drawing.Point(148, 10);
            this.MyStartDirectLoad.Name = "MyStartDirectLoad";
            this.MyStartDirectLoad.Size = new System.Drawing.Size(75, 23);
            this.MyStartDirectLoad.TabIndex = 33;
            this.MyStartDirectLoad.Text = "Load disk";
            this.MyStartDirectLoad.UseVisualStyleBackColor = true;
            this.MyStartDirectLoad.Click += new System.EventHandler(this.MyStartDirectLoad_Click);
            // 
            // LoadMyDirect
            // 
            this.LoadMyDirect.Location = new System.Drawing.Point(537, 11);
            this.LoadMyDirect.Name = "LoadMyDirect";
            this.LoadMyDirect.Size = new System.Drawing.Size(55, 23);
            this.LoadMyDirect.TabIndex = 34;
            this.LoadMyDirect.Text = "Load";
            this.LoadMyDirect.UseVisualStyleBackColor = true;
            this.LoadMyDirect.Click += new System.EventHandler(this.button1_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(598, 104);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(83, 23);
            this.UploadButton.TabIndex = 35;
            this.UploadButton.Text = "Upload =>";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(598, 212);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(83, 23);
            this.DownloadButton.TabIndex = 36;
            this.DownloadButton.Text = "<= Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(210, 386);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(60, 30);
            this.RenameButton.TabIndex = 37;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1014, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 30);
            this.button1.TabIndex = 38;
            this.button1.Text = "Rename";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DownloadBufferScB
            // 
            this.DownloadBufferScB.Location = new System.Drawing.Point(118, 549);
            this.DownloadBufferScB.Maximum = 2000000000;
            this.DownloadBufferScB.Minimum = 1048576;
            this.DownloadBufferScB.Name = "DownloadBufferScB";
            this.DownloadBufferScB.Size = new System.Drawing.Size(325, 17);
            this.DownloadBufferScB.TabIndex = 39;
            this.DownloadBufferScB.Value = 1048576;
            this.DownloadBufferScB.ValueChanged += new System.EventHandler(this.DownloadBufferScB_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Download buffer size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(852, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Upload buffer size";
            // 
            // UploadBufferScB
            // 
            this.UploadBufferScB.Location = new System.Drawing.Point(947, 542);
            this.UploadBufferScB.Maximum = 2000000000;
            this.UploadBufferScB.Minimum = 1048576;
            this.UploadBufferScB.Name = "UploadBufferScB";
            this.UploadBufferScB.Size = new System.Drawing.Size(325, 17);
            this.UploadBufferScB.TabIndex = 42;
            this.UploadBufferScB.Value = 1048576;
            this.UploadBufferScB.ValueChanged += new System.EventHandler(this.UploadBufferScB_ValueChanged);
            // 
            // DownloadBufferTextBox
            // 
            this.DownloadBufferTextBox.Location = new System.Drawing.Point(185, 526);
            this.DownloadBufferTextBox.Name = "DownloadBufferTextBox";
            this.DownloadBufferTextBox.ReadOnly = true;
            this.DownloadBufferTextBox.Size = new System.Drawing.Size(200, 20);
            this.DownloadBufferTextBox.TabIndex = 43;
            // 
            // UploadBufferTextBox
            // 
            this.UploadBufferTextBox.Location = new System.Drawing.Point(819, 519);
            this.UploadBufferTextBox.Name = "UploadBufferTextBox";
            this.UploadBufferTextBox.ReadOnly = true;
            this.UploadBufferTextBox.Size = new System.Drawing.Size(200, 20);
            this.UploadBufferTextBox.TabIndex = 44;
            // 
            // ScrollBarUpload
            // 
            this.ScrollBarUpload.Location = new System.Drawing.Point(1080, 519);
            this.ScrollBarUpload.Name = "ScrollBarUpload";
            this.ScrollBarUpload.ReadOnly = true;
            this.ScrollBarUpload.Size = new System.Drawing.Size(200, 20);
            this.ScrollBarUpload.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1025, 522);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "ScrollBar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 522);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Now:";
            // 
            // ChangeUploadBuffer
            // 
            this.ChangeUploadBuffer.Location = new System.Drawing.Point(771, 542);
            this.ChangeUploadBuffer.Name = "ChangeUploadBuffer";
            this.ChangeUploadBuffer.Size = new System.Drawing.Size(75, 23);
            this.ChangeUploadBuffer.TabIndex = 48;
            this.ChangeUploadBuffer.Text = "Change";
            this.ChangeUploadBuffer.UseVisualStyleBackColor = true;
            this.ChangeUploadBuffer.Click += new System.EventHandler(this.ChangeUploadBuffer_Click);
            // 
            // FileConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 575);
            this.Controls.Add(this.ChangeUploadBuffer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScrollBarUpload);
            this.Controls.Add(this.UploadBufferTextBox);
            this.Controls.Add(this.DownloadBufferTextBox);
            this.Controls.Add(this.UploadBufferScB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownloadBufferScB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.LoadMyDirect);
            this.Controls.Add(this.MyStartDirectLoad);
            this.Controls.Add(this.MyCompDirectBox);
            this.Controls.Add(this.GoNazadMyDirect);
            this.Controls.Add(this.MyFullDirectPole);
            this.Controls.Add(this.OtherCompDirectBox);
            this.Controls.Add(this.GoNazadOtherDirect);
            this.Controls.Add(this.GoZagruzitOtherDirect);
            this.Controls.Add(this.OtherFullDirectPole);
            this.Controls.Add(this.OtherStartDirectLoad);
            this.Controls.Add(this.ComboboxOfOtherComp);
            this.Controls.Add(this.ComboboxOfMyComp);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.OtherInsert);
            this.Controls.Add(this.OtherDelete);
            this.Controls.Add(this.OtherCopy);
            this.Controls.Add(this.MyInsert);
            this.Controls.Add(this.MyDelete);
            this.Controls.Add(this.MyCopy);
            this.Name = "FileConnectForm";
            this.Text = "FileConnectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button MyCopy;
        private System.Windows.Forms.Button MyDelete;
        private System.Windows.Forms.Button MyInsert;
        private System.Windows.Forms.Button OtherInsert;
        private System.Windows.Forms.Button OtherDelete;
        private System.Windows.Forms.Button OtherCopy;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        public System.Windows.Forms.ComboBox ComboboxOfMyComp;
        public System.Windows.Forms.ComboBox ComboboxOfOtherComp;
        private System.Windows.Forms.Button OtherStartDirectLoad;
        private System.Windows.Forms.TextBox OtherFullDirectPole;
        private System.Windows.Forms.Button GoZagruzitOtherDirect;
        private System.Windows.Forms.Button GoNazadOtherDirect;
        private System.Windows.Forms.ListView OtherCompDirectBox;
        private System.Windows.Forms.ImageList OtherDitectIcons;
        private System.Windows.Forms.TextBox MyFullDirectPole;
        private System.Windows.Forms.Button GoNazadMyDirect;
        private System.Windows.Forms.ListView MyCompDirectBox;
        private System.Windows.Forms.Button MyStartDirectLoad;
        private System.Windows.Forms.Button LoadMyDirect;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar DownloadBufferScB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar UploadBufferScB;
        private System.Windows.Forms.TextBox DownloadBufferTextBox;
        private System.Windows.Forms.TextBox UploadBufferTextBox;
        private System.Windows.Forms.TextBox ScrollBarUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChangeUploadBuffer;
    }
}