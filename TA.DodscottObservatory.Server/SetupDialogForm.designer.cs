namespace TA.DodscottObservatory.Server
{
    partial class SetupDialogForm
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
            System.Windows.Forms.ToolTip toolTip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialogForm));
            this.communicationSettingsControl1 = new TA.DodscottObservatory.Server.CommunicationSettingsControl();
            this.PerformShutterRecovery = new System.Windows.Forms.CheckBox();
            this.ShutterOpenCloseTimeSeconds = new System.Windows.Forms.NumericUpDown();
            this.FullRotationTimeSeconds = new System.Windows.Forms.NumericUpDown();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.AboutBox = new System.Windows.Forms.Button();
            this.ConnectionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CommunicationsGroup = new System.Windows.Forms.GroupBox();
            this.StartupOptionsGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ShutterOpenCloseTimeSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullRotationTimeSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionErrorProvider)).BeginInit();
            this.CommunicationsGroup.SuspendLayout();
            this.StartupOptionsGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 30000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 100;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Settings Help";
            // 
            // communicationSettingsControl1
            // 
            this.communicationSettingsControl1.AutoSize = true;
            this.communicationSettingsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.communicationSettingsControl1.Location = new System.Drawing.Point(6, 19);
            this.communicationSettingsControl1.Name = "communicationSettingsControl1";
            this.communicationSettingsControl1.Size = new System.Drawing.Size(232, 36);
            this.communicationSettingsControl1.TabIndex = 7;
            toolTip1.SetToolTip(this.communicationSettingsControl1, resources.GetString("communicationSettingsControl1.ToolTip"));
            // 
            // PerformShutterRecovery
            // 
            this.PerformShutterRecovery.AutoSize = true;
            this.PerformShutterRecovery.Checked = global::TA.DodscottObservatory.Server.Properties.Settings.Default.PerformShutterRecovery;
            this.PerformShutterRecovery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PerformShutterRecovery.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TA.DodscottObservatory.Server.Properties.Settings.Default, "PerformShutterRecovery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PerformShutterRecovery.Location = new System.Drawing.Point(7, 20);
            this.PerformShutterRecovery.Name = "PerformShutterRecovery";
            this.PerformShutterRecovery.Size = new System.Drawing.Size(266, 17);
            this.PerformShutterRecovery.TabIndex = 0;
            this.PerformShutterRecovery.Text = "Close shutter if position is not known upon connect";
            toolTip1.SetToolTip(this.PerformShutterRecovery, resources.GetString("PerformShutterRecovery.ToolTip"));
            this.PerformShutterRecovery.UseVisualStyleBackColor = true;
            // 
            // ShutterOpenCloseTimeSeconds
            // 
            this.ShutterOpenCloseTimeSeconds.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TA.DodscottObservatory.Server.Properties.Settings.Default, "ShutterOpenCloseTimeSeconds", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShutterOpenCloseTimeSeconds.Location = new System.Drawing.Point(175, 45);
            this.ShutterOpenCloseTimeSeconds.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.ShutterOpenCloseTimeSeconds.Name = "ShutterOpenCloseTimeSeconds";
            this.ShutterOpenCloseTimeSeconds.Size = new System.Drawing.Size(80, 20);
            this.ShutterOpenCloseTimeSeconds.TabIndex = 1;
            this.ShutterOpenCloseTimeSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            toolTip1.SetToolTip(this.ShutterOpenCloseTimeSeconds, resources.GetString("ShutterOpenCloseTimeSeconds.ToolTip"));
            this.ShutterOpenCloseTimeSeconds.Value = global::TA.DodscottObservatory.Server.Properties.Settings.Default.ShutterOpenCloseTimeSeconds;
            // 
            // FullRotationTimeSeconds
            // 
            this.FullRotationTimeSeconds.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TA.DodscottObservatory.Server.Properties.Settings.Default, "FullRotationTimeSeconds", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FullRotationTimeSeconds.Location = new System.Drawing.Point(175, 19);
            this.FullRotationTimeSeconds.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.FullRotationTimeSeconds.Name = "FullRotationTimeSeconds";
            this.FullRotationTimeSeconds.Size = new System.Drawing.Size(80, 20);
            this.FullRotationTimeSeconds.TabIndex = 1;
            this.FullRotationTimeSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            toolTip1.SetToolTip(this.FullRotationTimeSeconds, resources.GetString("FullRotationTimeSeconds.ToolTip"));
            this.FullRotationTimeSeconds.Value = global::TA.DodscottObservatory.Server.Properties.Settings.Default.FullRotationTimeSeconds;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(327, 201);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(327, 231);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::TA.DodscottObservatory.Server.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(340, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // AboutBox
            // 
            this.AboutBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutBox.Location = new System.Drawing.Point(327, 173);
            this.AboutBox.Name = "AboutBox";
            this.AboutBox.Size = new System.Drawing.Size(59, 23);
            this.AboutBox.TabIndex = 8;
            this.AboutBox.Text = "About...";
            this.AboutBox.UseVisualStyleBackColor = true;
            this.AboutBox.Click += new System.EventHandler(this.AboutBox_Click);
            // 
            // ConnectionErrorProvider
            // 
            this.ConnectionErrorProvider.BlinkRate = 1000;
            this.ConnectionErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.ConnectionErrorProvider.ContainerControl = this;
            // 
            // CommunicationsGroup
            // 
            this.CommunicationsGroup.Controls.Add(this.communicationSettingsControl1);
            this.CommunicationsGroup.Location = new System.Drawing.Point(12, 12);
            this.CommunicationsGroup.Name = "CommunicationsGroup";
            this.CommunicationsGroup.Size = new System.Drawing.Size(303, 74);
            this.CommunicationsGroup.TabIndex = 9;
            this.CommunicationsGroup.TabStop = false;
            this.CommunicationsGroup.Text = "Communications";
            // 
            // StartupOptionsGroup
            // 
            this.StartupOptionsGroup.Controls.Add(this.PerformShutterRecovery);
            this.StartupOptionsGroup.Location = new System.Drawing.Point(12, 92);
            this.StartupOptionsGroup.Name = "StartupOptionsGroup";
            this.StartupOptionsGroup.Size = new System.Drawing.Size(303, 70);
            this.StartupOptionsGroup.TabIndex = 10;
            this.StartupOptionsGroup.TabStop = false;
            this.StartupOptionsGroup.Text = "Startup Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FullRotationTimeSeconds);
            this.groupBox1.Controls.Add(this.ShutterOpenCloseTimeSeconds);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 87);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timeouts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shutter open/close (seconds)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full rotation (seconds)";
            // 
            // SetupDialogForm
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartupOptionsGroup);
            this.Controls.Add(this.CommunicationsGroup);
            this.Controls.Add(this.AboutBox);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::TA.DodscottObservatory.Server.Properties.Settings.Default, "SetupDialogLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = global::TA.DodscottObservatory.Server.Properties.Settings.Default.SetupDialogLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 213);
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCOM Drivers for Digital Domeworks Setup";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShutterOpenCloseTimeSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullRotationTimeSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionErrorProvider)).EndInit();
            this.CommunicationsGroup.ResumeLayout(false);
            this.CommunicationsGroup.PerformLayout();
            this.StartupOptionsGroup.ResumeLayout(false);
            this.StartupOptionsGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private CommunicationSettingsControl communicationSettingsControl1;
        private System.Windows.Forms.Button AboutBox;
        private System.Windows.Forms.ErrorProvider ConnectionErrorProvider;
        private System.Windows.Forms.GroupBox CommunicationsGroup;
        private System.Windows.Forms.GroupBox StartupOptionsGroup;
        private System.Windows.Forms.CheckBox PerformShutterRecovery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown ShutterOpenCloseTimeSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FullRotationTimeSeconds;
        }
}