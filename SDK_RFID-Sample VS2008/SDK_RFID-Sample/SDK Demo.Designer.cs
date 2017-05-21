namespace SDK_RFID_Sample
{
    partial class SDK_Demo
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFP = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDispose = new System.Windows.Forms.Button();
            this.groupBoxCtrl = new System.Windows.Forms.GroupBox();
            this.labelInventoryTagCount = new System.Windows.Forms.Label();
            this.listBoxTag = new System.Windows.Forms.ListBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFP = new System.Windows.Forms.ComboBox();
            this.groupBoxFP = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonEnrol = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.groupBoxCtrl.SuspendLayout();
            this.groupBoxFP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID Device : ";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(318, 23);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(92, 33);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create Device";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripStatusLabelFP});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabelInfo.Text = "Info RFID:";
            // 
            // toolStripStatusLabelFP
            // 
            this.toolStripStatusLabelFP.Name = "toolStripStatusLabelFP";
            this.toolStripStatusLabelFP.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabelFP.Text = "      - Info FP :";
            this.toolStripStatusLabelFP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonDispose
            // 
            this.buttonDispose.Enabled = false;
            this.buttonDispose.Location = new System.Drawing.Point(416, 23);
            this.buttonDispose.Name = "buttonDispose";
            this.buttonDispose.Size = new System.Drawing.Size(92, 33);
            this.buttonDispose.TabIndex = 4;
            this.buttonDispose.Text = "Dispose Device";
            this.buttonDispose.UseVisualStyleBackColor = true;
            this.buttonDispose.Click += new System.EventHandler(this.buttonDispose_Click);
            // 
            // groupBoxCtrl
            // 
            this.groupBoxCtrl.Controls.Add(this.labelInventoryTagCount);
            this.groupBoxCtrl.Controls.Add(this.listBoxTag);
            this.groupBoxCtrl.Controls.Add(this.buttonStop);
            this.groupBoxCtrl.Controls.Add(this.buttonScan);
            this.groupBoxCtrl.Enabled = false;
            this.groupBoxCtrl.Location = new System.Drawing.Point(15, 71);
            this.groupBoxCtrl.Name = "groupBoxCtrl";
            this.groupBoxCtrl.Size = new System.Drawing.Size(591, 212);
            this.groupBoxCtrl.TabIndex = 5;
            this.groupBoxCtrl.TabStop = false;
            this.groupBoxCtrl.Text = "RFID";
            // 
            // labelInventoryTagCount
            // 
            this.labelInventoryTagCount.AutoSize = true;
            this.labelInventoryTagCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInventoryTagCount.Location = new System.Drawing.Point(464, 30);
            this.labelInventoryTagCount.Name = "labelInventoryTagCount";
            this.labelInventoryTagCount.Size = new System.Drawing.Size(104, 24);
            this.labelInventoryTagCount.TabIndex = 3;
            this.labelInventoryTagCount.Text = "Tag(s): 000";
            // 
            // listBoxTag
            // 
            this.listBoxTag.ColumnWidth = 100;
            this.listBoxTag.FormattingEnabled = true;
            this.listBoxTag.Location = new System.Drawing.Point(20, 71);
            this.listBoxTag.MultiColumn = true;
            this.listBoxTag.Name = "listBoxTag";
            this.listBoxTag.Size = new System.Drawing.Size(548, 134);
            this.listBoxTag.TabIndex = 2;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(105, 21);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(67, 33);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(20, 21);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(67, 33);
            this.buttonScan.TabIndex = 0;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(514, 23);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(92, 33);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(87, 14);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(225, 21);
            this.comboBoxDevice.TabIndex = 7;
            this.comboBoxDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevice_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "FP Device : ";
            // 
            // comboBoxFP
            // 
            this.comboBoxFP.FormattingEnabled = true;
            this.comboBoxFP.Location = new System.Drawing.Point(87, 44);
            this.comboBoxFP.Name = "comboBoxFP";
            this.comboBoxFP.Size = new System.Drawing.Size(225, 21);
            this.comboBoxFP.TabIndex = 9;
            this.comboBoxFP.SelectedIndexChanged += new System.EventHandler(this.comboBoxFP_SelectedIndexChanged);
            // 
            // groupBoxFP
            // 
            this.groupBoxFP.Controls.Add(this.label5);
            this.groupBoxFP.Controls.Add(this.buttonEnrol);
            this.groupBoxFP.Controls.Add(this.label4);
            this.groupBoxFP.Controls.Add(this.label3);
            this.groupBoxFP.Controls.Add(this.textBoxLastName);
            this.groupBoxFP.Controls.Add(this.textBoxFirstName);
            this.groupBoxFP.Controls.Add(this.listBoxUser);
            this.groupBoxFP.Location = new System.Drawing.Point(15, 300);
            this.groupBoxFP.Name = "groupBoxFP";
            this.groupBoxFP.Size = new System.Drawing.Size(590, 115);
            this.groupBoxFP.TabIndex = 10;
            this.groupBoxFP.TabStop = false;
            this.groupBoxFP.Text = "FingerPrint";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Double click list to modify user";
            // 
            // buttonEnrol
            // 
            this.buttonEnrol.Location = new System.Drawing.Point(447, 30);
            this.buttonEnrol.Name = "buttonEnrol";
            this.buttonEnrol.Size = new System.Drawing.Size(80, 37);
            this.buttonEnrol.TabIndex = 5;
            this.buttonEnrol.Text = "Enrol !";
            this.buttonEnrol.UseVisualStyleBackColor = true;
            this.buttonEnrol.Click += new System.EventHandler(this.buttonEnrol_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Last Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "First Name :";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(320, 53);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(112, 20);
            this.textBoxLastName.TabIndex = 2;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(320, 27);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(112, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // listBoxUser
            // 
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.Location = new System.Drawing.Point(16, 23);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(212, 69);
            this.listBoxUser.TabIndex = 0;
            this.listBoxUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxUser_MouseDoubleClick);
            // 
            // SDK_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 449);
            this.Controls.Add(this.groupBoxFP);
            this.Controls.Add(this.comboBoxFP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.groupBoxCtrl);
            this.Controls.Add(this.buttonDispose);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SDK_Demo";
            this.Text = "SDK_Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SDK_Demo_FormClosing);
            this.Load += new System.EventHandler(this.SDK_Demo_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxCtrl.ResumeLayout(false);
            this.groupBoxCtrl.PerformLayout();
            this.groupBoxFP.ResumeLayout(false);
            this.groupBoxFP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.Button buttonDispose;
        private System.Windows.Forms.GroupBox groupBoxCtrl;
        private System.Windows.Forms.Label labelInventoryTagCount;
        private System.Windows.Forms.ListBox listBoxTag;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFP;
        private System.Windows.Forms.GroupBox groupBoxFP;
        private System.Windows.Forms.Button buttonEnrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.Label label5;
    }
}