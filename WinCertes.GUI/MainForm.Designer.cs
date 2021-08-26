﻿
namespace WinCertes.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iisGroupBox = new System.Windows.Forms.GroupBox();
            this.iisPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.iisCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sniCheckBox = new System.Windows.Forms.CheckBox();
            this.sitesListBox = new System.Windows.Forms.ListBox();
            this.webRootLabel = new System.Windows.Forms.Label();
            this.bindingsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.domainsGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.domainsListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.psExecComboBox = new System.Windows.Forms.ComboBox();
            this.psExecCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.psScriptTextBox = new System.Windows.Forms.TextBox();
            this.psScriptCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.taskCheckBox = new System.Windows.Forms.CheckBox();
            this.renewalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.registeredLabel = new System.Windows.Forms.Label();
            this.iisRadioButton = new System.Windows.Forms.RadioButton();
            this.standaloneRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.serviceComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.issueButton = new System.Windows.Forms.Button();
            this.revokeButton = new System.Windows.Forms.Button();
            this.certButton = new System.Windows.Forms.Button();
            this.standaloneGroupBox = new System.Windows.Forms.GroupBox();
            this.httpPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkPortButton = new System.Windows.Forms.Button();
            this.inUseLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.configsComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newConfigButton = new System.Windows.Forms.Button();
            this.iisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).BeginInit();
            this.domainsGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.standaloneGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // iisGroupBox
            // 
            this.iisGroupBox.Controls.Add(this.iisPortNumericUpDown);
            this.iisGroupBox.Controls.Add(this.iisCheckBox);
            this.iisGroupBox.Controls.Add(this.label7);
            this.iisGroupBox.Controls.Add(this.sniCheckBox);
            this.iisGroupBox.Controls.Add(this.sitesListBox);
            this.iisGroupBox.Controls.Add(this.webRootLabel);
            this.iisGroupBox.Controls.Add(this.bindingsListBox);
            this.iisGroupBox.Controls.Add(this.label3);
            this.iisGroupBox.Controls.Add(this.label2);
            this.iisGroupBox.Location = new System.Drawing.Point(12, 542);
            this.iisGroupBox.Name = "iisGroupBox";
            this.iisGroupBox.Size = new System.Drawing.Size(1324, 387);
            this.iisGroupBox.TabIndex = 35;
            this.iisGroupBox.TabStop = false;
            this.iisGroupBox.Text = "IIS Settings";
            // 
            // iisPortNumericUpDown
            // 
            this.iisPortNumericUpDown.Location = new System.Drawing.Point(739, 314);
            this.iisPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iisPortNumericUpDown.Name = "iisPortNumericUpDown";
            this.iisPortNumericUpDown.Size = new System.Drawing.Size(153, 39);
            this.iisPortNumericUpDown.TabIndex = 43;
            this.iisPortNumericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            this.iisPortNumericUpDown.ValueChanged += new System.EventHandler(this.iisPortNumericUpDown_ValueChanged);
            // 
            // iisCheckBox
            // 
            this.iisCheckBox.AutoSize = true;
            this.iisCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iisCheckBox.Location = new System.Drawing.Point(1078, 80);
            this.iisCheckBox.Name = "iisCheckBox";
            this.iisCheckBox.Size = new System.Drawing.Size(214, 36);
            this.iisCheckBox.TabIndex = 42;
            this.iisCheckBox.Text = "Bind to IIS Site";
            this.iisCheckBox.UseVisualStyleBackColor = true;
            this.iisCheckBox.CheckedChanged += new System.EventHandler(this.iisCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(506, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 32);
            this.label7.TabIndex = 40;
            this.label7.Text = "IIS Port to bind to:";
            // 
            // sniCheckBox
            // 
            this.sniCheckBox.AutoSize = true;
            this.sniCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sniCheckBox.Location = new System.Drawing.Point(989, 315);
            this.sniCheckBox.Name = "sniCheckBox";
            this.sniCheckBox.Size = new System.Drawing.Size(316, 36);
            this.sniCheckBox.TabIndex = 39;
            this.sniCheckBox.Text = "Server Name Indication";
            this.sniCheckBox.UseVisualStyleBackColor = true;
            this.sniCheckBox.CheckedChanged += new System.EventHandler(this.sniCheckBox_CheckedChanged);
            // 
            // sitesListBox
            // 
            this.sitesListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.sitesListBox.FormattingEnabled = true;
            this.sitesListBox.ItemHeight = 32;
            this.sitesListBox.Location = new System.Drawing.Point(6, 80);
            this.sitesListBox.Name = "sitesListBox";
            this.sitesListBox.Size = new System.Drawing.Size(484, 292);
            this.sitesListBox.TabIndex = 38;
            this.sitesListBox.SelectedIndexChanged += new System.EventHandler(this.sitesListBox_SelectedIndexChanged);
            // 
            // webRootLabel
            // 
            this.webRootLabel.Location = new System.Drawing.Point(305, 35);
            this.webRootLabel.Name = "webRootLabel";
            this.webRootLabel.Size = new System.Drawing.Size(970, 32);
            this.webRootLabel.TabIndex = 37;
            // 
            // bindingsListBox
            // 
            this.bindingsListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bindingsListBox.FormattingEnabled = true;
            this.bindingsListBox.ItemHeight = 32;
            this.bindingsListBox.Location = new System.Drawing.Point(506, 134);
            this.bindingsListBox.Name = "bindingsListBox";
            this.bindingsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.bindingsListBox.Size = new System.Drawing.Size(799, 164);
            this.bindingsListBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 32);
            this.label3.TabIndex = 35;
            this.label3.Text = "Web Root for Challange:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(506, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 32);
            this.label2.TabIndex = 34;
            this.label2.Text = "Site Bindings:";
            // 
            // domainsGroupBox
            // 
            this.domainsGroupBox.Controls.Add(this.label4);
            this.domainsGroupBox.Controls.Add(this.addButton);
            this.domainsGroupBox.Controls.Add(this.domainTextBox);
            this.domainsGroupBox.Controls.Add(this.label5);
            this.domainsGroupBox.Controls.Add(this.removeButton);
            this.domainsGroupBox.Controls.Add(this.domainsListBox);
            this.domainsGroupBox.Location = new System.Drawing.Point(12, 935);
            this.domainsGroupBox.Name = "domainsGroupBox";
            this.domainsGroupBox.Size = new System.Drawing.Size(1324, 294);
            this.domainsGroupBox.TabIndex = 37;
            this.domainsGroupBox.TabStop = false;
            this.domainsGroupBox.Text = "Domains";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(17, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 32);
            this.label4.TabIndex = 42;
            this.label4.Text = "Domains to Generate certifcate for:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1175, 236);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 46);
            this.addButton.TabIndex = 41;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // domainTextBox
            // 
            this.domainTextBox.Location = new System.Drawing.Point(194, 240);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(975, 39);
            this.domainTextBox.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 32);
            this.label5.TabIndex = 39;
            this.label5.Text = "New Domain:";
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(1175, 70);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(130, 46);
            this.removeButton.TabIndex = 38;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // domainsListBox
            // 
            this.domainsListBox.FormattingEnabled = true;
            this.domainsListBox.ItemHeight = 32;
            this.domainsListBox.Location = new System.Drawing.Point(17, 70);
            this.domainsListBox.Name = "domainsListBox";
            this.domainsListBox.Size = new System.Drawing.Size(1152, 164);
            this.domainsListBox.TabIndex = 37;
            this.domainsListBox.SelectedIndexChanged += new System.EventHandler(this.domainsListBox_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.psExecComboBox);
            this.groupBox3.Controls.Add(this.psExecCheckBox);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.psScriptTextBox);
            this.groupBox3.Controls.Add(this.psScriptCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 1235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1324, 145);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PowerShell Core Script";
            // 
            // psExecComboBox
            // 
            this.psExecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.psExecComboBox.FormattingEnabled = true;
            this.psExecComboBox.Location = new System.Drawing.Point(384, 89);
            this.psExecComboBox.Name = "psExecComboBox";
            this.psExecComboBox.Size = new System.Drawing.Size(379, 40);
            this.psExecComboBox.TabIndex = 34;
            this.psExecComboBox.SelectedIndexChanged += new System.EventHandler(this.psExecComboBox_SelectedIndexChanged);
            // 
            // psExecCheckBox
            // 
            this.psExecCheckBox.AutoSize = true;
            this.psExecCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psExecCheckBox.Location = new System.Drawing.Point(6, 91);
            this.psExecCheckBox.Name = "psExecCheckBox";
            this.psExecCheckBox.Size = new System.Drawing.Size(372, 36);
            this.psExecCheckBox.TabIndex = 33;
            this.psExecCheckBox.Text = "PowerShell Execution Policy:";
            this.psExecCheckBox.UseVisualStyleBackColor = true;
            this.psExecCheckBox.CheckedChanged += new System.EventHandler(this.psExecCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(1175, 32);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(130, 46);
            this.browseButton.TabIndex = 32;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // psScriptTextBox
            // 
            this.psScriptTextBox.Location = new System.Drawing.Point(358, 36);
            this.psScriptTextBox.Name = "psScriptTextBox";
            this.psScriptTextBox.Size = new System.Drawing.Size(811, 39);
            this.psScriptTextBox.TabIndex = 31;
            this.psScriptTextBox.TextChanged += new System.EventHandler(this.psScriptTextBox_TextChanged);
            // 
            // psScriptCheckBox
            // 
            this.psScriptCheckBox.AutoSize = true;
            this.psScriptCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.psScriptCheckBox.Location = new System.Drawing.Point(6, 38);
            this.psScriptCheckBox.Name = "psScriptCheckBox";
            this.psScriptCheckBox.Size = new System.Drawing.Size(346, 36);
            this.psScriptCheckBox.TabIndex = 30;
            this.psScriptCheckBox.Text = "Execute PowerShell Script:";
            this.psScriptCheckBox.UseVisualStyleBackColor = true;
            this.psScriptCheckBox.CheckedChanged += new System.EventHandler(this.psScriptCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.taskCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(781, 359);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(555, 177);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scheduled Task";
            // 
            // taskCheckBox
            // 
            this.taskCheckBox.AutoSize = true;
            this.taskCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.taskCheckBox.Location = new System.Drawing.Point(6, 38);
            this.taskCheckBox.Name = "taskCheckBox";
            this.taskCheckBox.Size = new System.Drawing.Size(503, 36);
            this.taskCheckBox.TabIndex = 35;
            this.taskCheckBox.Text = "Schedule a Task to Renew Automatically";
            this.taskCheckBox.UseVisualStyleBackColor = true;
            this.taskCheckBox.CheckedChanged += new System.EventHandler(this.taskCheckBox_CheckedChanged);
            // 
            // renewalNumericUpDown
            // 
            this.renewalNumericUpDown.Location = new System.Drawing.Point(1157, 452);
            this.renewalNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.renewalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.renewalNumericUpDown.Name = "renewalNumericUpDown";
            this.renewalNumericUpDown.Size = new System.Drawing.Size(160, 39);
            this.renewalNumericUpDown.TabIndex = 44;
            this.renewalNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.renewalNumericUpDown.ValueChanged += new System.EventHandler(this.renewalNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(787, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 32);
            this.label1.TabIndex = 36;
            this.label1.Text = "Renew Days before Expiration:";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.registeredLabel);
            this.settingsGroupBox.Controls.Add(this.iisRadioButton);
            this.settingsGroupBox.Controls.Add(this.standaloneRadioButton);
            this.settingsGroupBox.Controls.Add(this.label9);
            this.settingsGroupBox.Controls.Add(this.serviceComboBox);
            this.settingsGroupBox.Controls.Add(this.label8);
            this.settingsGroupBox.Controls.Add(this.emailTextBox);
            this.settingsGroupBox.Controls.Add(this.label6);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 136);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(1042, 217);
            this.settingsGroupBox.TabIndex = 40;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // registeredLabel
            // 
            this.registeredLabel.AutoSize = true;
            this.registeredLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.registeredLabel.Location = new System.Drawing.Point(746, 35);
            this.registeredLabel.Name = "registeredLabel";
            this.registeredLabel.Size = new System.Drawing.Size(153, 32);
            this.registeredLabel.TabIndex = 33;
            this.registeredLabel.Text = "REGISTERED";
            this.registeredLabel.Visible = false;
            // 
            // iisRadioButton
            // 
            this.iisRadioButton.AutoSize = true;
            this.iisRadioButton.Location = new System.Drawing.Point(434, 151);
            this.iisRadioButton.Name = "iisRadioButton";
            this.iisRadioButton.Size = new System.Drawing.Size(205, 36);
            this.iisRadioButton.TabIndex = 31;
            this.iisRadioButton.TabStop = true;
            this.iisRadioButton.Text = "Local IIS Server";
            this.iisRadioButton.UseVisualStyleBackColor = true;
            this.iisRadioButton.CheckedChanged += new System.EventHandler(this.iisRadioButton_CheckedChanged);
            // 
            // standaloneRadioButton
            // 
            this.standaloneRadioButton.AutoSize = true;
            this.standaloneRadioButton.Location = new System.Drawing.Point(116, 151);
            this.standaloneRadioButton.Name = "standaloneRadioButton";
            this.standaloneRadioButton.Size = new System.Drawing.Size(301, 36);
            this.standaloneRadioButton.TabIndex = 30;
            this.standaloneRadioButton.TabStop = true;
            this.standaloneRadioButton.Text = "Standalone HTTP Server";
            this.standaloneRadioButton.UseVisualStyleBackColor = true;
            this.standaloneRadioButton.CheckedChanged += new System.EventHandler(this.standaloneRadioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(6, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 32);
            this.label9.TabIndex = 29;
            this.label9.Text = "Server:";
            // 
            // serviceComboBox
            // 
            this.serviceComboBox.FormattingEnabled = true;
            this.serviceComboBox.Location = new System.Drawing.Point(116, 89);
            this.serviceComboBox.Name = "serviceComboBox";
            this.serviceComboBox.Size = new System.Drawing.Size(624, 40);
            this.serviceComboBox.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 32);
            this.label8.TabIndex = 27;
            this.label8.Text = "Service:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(116, 32);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(624, 39);
            this.emailTextBox.TabIndex = 26;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 32);
            this.label6.TabIndex = 25;
            this.label6.Text = "e-mail*:";
            // 
            // issueButton
            // 
            this.issueButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.issueButton.Location = new System.Drawing.Point(1060, 289);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(257, 46);
            this.issueButton.TabIndex = 35;
            this.issueButton.Text = "Issue Certificate";
            this.issueButton.UseVisualStyleBackColor = true;
            this.issueButton.Visible = false;
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);
            // 
            // revokeButton
            // 
            this.revokeButton.Location = new System.Drawing.Point(1060, 221);
            this.revokeButton.Name = "revokeButton";
            this.revokeButton.Size = new System.Drawing.Size(257, 46);
            this.revokeButton.TabIndex = 34;
            this.revokeButton.Text = "Revoke Certificate";
            this.revokeButton.UseVisualStyleBackColor = true;
            this.revokeButton.Visible = false;
            this.revokeButton.Click += new System.EventHandler(this.revokeButton_ClickAsync);
            // 
            // certButton
            // 
            this.certButton.Location = new System.Drawing.Point(1060, 157);
            this.certButton.Name = "certButton";
            this.certButton.Size = new System.Drawing.Size(257, 46);
            this.certButton.TabIndex = 32;
            this.certButton.Text = "Show Certificate";
            this.certButton.UseVisualStyleBackColor = true;
            this.certButton.Visible = false;
            this.certButton.Click += new System.EventHandler(this.certButton_Click);
            // 
            // standaloneGroupBox
            // 
            this.standaloneGroupBox.Controls.Add(this.httpPortNumericUpDown);
            this.standaloneGroupBox.Controls.Add(this.checkPortButton);
            this.standaloneGroupBox.Controls.Add(this.inUseLabel);
            this.standaloneGroupBox.Controls.Add(this.label12);
            this.standaloneGroupBox.Controls.Add(this.label11);
            this.standaloneGroupBox.Location = new System.Drawing.Point(12, 359);
            this.standaloneGroupBox.Name = "standaloneGroupBox";
            this.standaloneGroupBox.Size = new System.Drawing.Size(763, 177);
            this.standaloneGroupBox.TabIndex = 41;
            this.standaloneGroupBox.TabStop = false;
            this.standaloneGroupBox.Text = "Standalone HTTP Server Settings";
            // 
            // httpPortNumericUpDown
            // 
            this.httpPortNumericUpDown.Location = new System.Drawing.Point(162, 38);
            this.httpPortNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.httpPortNumericUpDown.Name = "httpPortNumericUpDown";
            this.httpPortNumericUpDown.Size = new System.Drawing.Size(153, 39);
            this.httpPortNumericUpDown.TabIndex = 5;
            this.httpPortNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.httpPortNumericUpDown.ValueChanged += new System.EventHandler(this.httpPortNumericUpDown_ValueChanged);
            // 
            // checkPortButton
            // 
            this.checkPortButton.Location = new System.Drawing.Point(506, 34);
            this.checkPortButton.Name = "checkPortButton";
            this.checkPortButton.Size = new System.Drawing.Size(189, 46);
            this.checkPortButton.TabIndex = 4;
            this.checkPortButton.Text = "Check Port";
            this.checkPortButton.UseVisualStyleBackColor = true;
            this.checkPortButton.Visible = false;
            this.checkPortButton.Click += new System.EventHandler(this.checkPortButton_Click);
            // 
            // inUseLabel
            // 
            this.inUseLabel.AutoSize = true;
            this.inUseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.inUseLabel.ForeColor = System.Drawing.Color.Red;
            this.inUseLabel.Location = new System.Drawing.Point(330, 41);
            this.inUseLabel.Name = "inUseLabel";
            this.inUseLabel.Size = new System.Drawing.Size(160, 32);
            this.inUseLabel.TabIndex = 3;
            this.inUseLabel.Text = "PORT IN USE";
            this.inUseLabel.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(728, 65);
            this.label12.TabIndex = 2;
            this.label12.Text = "All Challenges are processed on Port 80, if you use a different port above you mu" +
    "st set Port Forwarding on your Router accordingly.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "Server Port:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 32);
            this.label10.TabIndex = 42;
            this.label10.Text = "Configuration:";
            // 
            // configsComboBox
            // 
            this.configsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configsComboBox.FormattingEnabled = true;
            this.configsComboBox.Location = new System.Drawing.Point(206, 53);
            this.configsComboBox.Name = "configsComboBox";
            this.configsComboBox.Size = new System.Drawing.Size(445, 40);
            this.configsComboBox.TabIndex = 43;
            this.configsComboBox.SelectedIndexChanged += new System.EventHandler(this.configsComboBox_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(657, 49);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(150, 46);
            this.deleteButton.TabIndex = 44;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newConfigButton
            // 
            this.newConfigButton.Location = new System.Drawing.Point(1060, 46);
            this.newConfigButton.Name = "newConfigButton";
            this.newConfigButton.Size = new System.Drawing.Size(257, 46);
            this.newConfigButton.TabIndex = 45;
            this.newConfigButton.Text = "New Configuration";
            this.newConfigButton.UseVisualStyleBackColor = true;
            this.newConfigButton.Click += new System.EventHandler(this.newConfigButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 1398);
            this.Controls.Add(this.renewalNumericUpDown);
            this.Controls.Add(this.issueButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newConfigButton);
            this.Controls.Add(this.revokeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.configsComboBox);
            this.Controls.Add(this.certButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.iisGroupBox);
            this.Controls.Add(this.standaloneGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.domainsGroupBox);
            this.Name = "MainForm";
            this.Text = "WinCertes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.iisGroupBox.ResumeLayout(false);
            this.iisGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisPortNumericUpDown)).EndInit();
            this.domainsGroupBox.ResumeLayout(false);
            this.domainsGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renewalNumericUpDown)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.standaloneGroupBox.ResumeLayout(false);
            this.standaloneGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox iisGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox sniCheckBox;
        private System.Windows.Forms.ListBox sitesListBox;
        private System.Windows.Forms.Label webRootLabel;
        private System.Windows.Forms.ListBox bindingsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox domainsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox domainsListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox psExecComboBox;
        private System.Windows.Forms.CheckBox psExecCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox psScriptTextBox;
        private System.Windows.Forms.CheckBox psScriptCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox taskCheckBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.ComboBox serviceComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox standaloneGroupBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton iisRadioButton;
        private System.Windows.Forms.RadioButton standaloneRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox iisCheckBox;
        private System.Windows.Forms.Button certButton;
        private System.Windows.Forms.Label registeredLabel;
        private System.Windows.Forms.Button revokeButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox configsComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label inUseLabel;
        private System.Windows.Forms.Button checkPortButton;
        private System.Windows.Forms.NumericUpDown iisPortNumericUpDown;
        private System.Windows.Forms.NumericUpDown renewalNumericUpDown;
        private System.Windows.Forms.NumericUpDown httpPortNumericUpDown;
        private System.Windows.Forms.Button issueButton;
        private System.Windows.Forms.Button newConfigButton;
    }
}

