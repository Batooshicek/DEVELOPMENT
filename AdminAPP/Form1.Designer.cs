namespace AdminAPP
{
    partial class Form1
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.Modules = new System.Windows.Forms.ListBox();
            this.Fields = new System.Windows.Forms.ListBox();
            this.Parameters = new System.Windows.Forms.ListBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.DateFromLabel = new System.Windows.Forms.Label();
            this.DateToLabel = new System.Windows.Forms.Label();
            this.IDText = new System.Windows.Forms.TextBox();
            this.ValueText = new System.Windows.Forms.TextBox();
            this.DateFromDTP = new System.Windows.Forms.DateTimePicker();
            this.DateToDTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(824, 354);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "SAVE";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(743, 354);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAdd);
            // 
            // Modules
            // 
            this.Modules.FormattingEnabled = true;
            this.Modules.Location = new System.Drawing.Point(12, 25);
            this.Modules.Name = "Modules";
            this.Modules.Size = new System.Drawing.Size(170, 381);
            this.Modules.TabIndex = 5;
            this.Modules.SelectedIndexChanged += new System.EventHandler(this.ModuleIndexChange);
            // 
            // Fields
            // 
            this.Fields.FormattingEnabled = true;
            this.Fields.Location = new System.Drawing.Point(197, 25);
            this.Fields.Name = "Fields";
            this.Fields.Size = new System.Drawing.Size(179, 381);
            this.Fields.TabIndex = 6;
            this.Fields.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexFields);
            // 
            // Parameters
            // 
            this.Parameters.FormattingEnabled = true;
            this.Parameters.Location = new System.Drawing.Point(401, 25);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(196, 381);
            this.Parameters.TabIndex = 7;
            this.Parameters.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexParameters);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(624, 23);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 8;
            this.IDLabel.Text = "ID";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(624, 51);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(34, 13);
            this.ValueLabel.TabIndex = 9;
            this.ValueLabel.Text = "Value";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(624, 83);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 10;
            this.TypeLabel.Text = "Type";
            // 
            // DateFromLabel
            // 
            this.DateFromLabel.AutoSize = true;
            this.DateFromLabel.Location = new System.Drawing.Point(624, 114);
            this.DateFromLabel.Name = "DateFromLabel";
            this.DateFromLabel.Size = new System.Drawing.Size(53, 13);
            this.DateFromLabel.TabIndex = 11;
            this.DateFromLabel.Text = "DateFrom";
            // 
            // DateToLabel
            // 
            this.DateToLabel.AutoSize = true;
            this.DateToLabel.Location = new System.Drawing.Point(624, 146);
            this.DateToLabel.Name = "DateToLabel";
            this.DateToLabel.Size = new System.Drawing.Size(43, 13);
            this.DateToLabel.TabIndex = 12;
            this.DateToLabel.Text = "DateTo";
            // 
            // IDText
            // 
            this.IDText.Location = new System.Drawing.Point(699, 20);
            this.IDText.Name = "IDText";
            this.IDText.ReadOnly = true;
            this.IDText.Size = new System.Drawing.Size(200, 20);
            this.IDText.TabIndex = 13;
            // 
            // ValueText
            // 
            this.ValueText.Location = new System.Drawing.Point(699, 48);
            this.ValueText.Name = "ValueText";
            this.ValueText.ReadOnly = true;
            this.ValueText.Size = new System.Drawing.Size(200, 20);
            this.ValueText.TabIndex = 14;
            this.ValueText.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // DateFromDTP
            // 
            this.DateFromDTP.Enabled = false;
            this.DateFromDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateFromDTP.Location = new System.Drawing.Point(699, 108);
            this.DateFromDTP.Name = "DateFromDTP";
            this.DateFromDTP.Size = new System.Drawing.Size(200, 20);
            this.DateFromDTP.TabIndex = 15;
            this.DateFromDTP.ValueChanged += new System.EventHandler(this.DateFromChange);
            // 
            // DateToDTP
            // 
            this.DateToDTP.Enabled = false;
            this.DateToDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateToDTP.Location = new System.Drawing.Point(699, 140);
            this.DateToDTP.Name = "DateToDTP";
            this.DateToDTP.Size = new System.Drawing.Size(200, 20);
            this.DateToDTP.TabIndex = 16;
            this.DateToDTP.ValueChanged += new System.EventHandler(this.DateToChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Modules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fields";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Parameters";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Enabled = false;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(697, 81);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(202, 21);
            this.comboBoxType.TabIndex = 20;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.TypeChange);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(911, 419);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateToDTP);
            this.Controls.Add(this.DateFromDTP);
            this.Controls.Add(this.ValueText);
            this.Controls.Add(this.IDText);
            this.Controls.Add(this.DateToLabel);
            this.Controls.Add(this.DateFromLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.Parameters);
            this.Controls.Add(this.Fields);
            this.Controls.Add(this.Modules);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SaveButton);
            this.Name = "Form1";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox Modules;
        private System.Windows.Forms.ListBox Fields;
        private System.Windows.Forms.ListBox Parameters;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label DateFromLabel;
        private System.Windows.Forms.Label DateToLabel;
        private System.Windows.Forms.TextBox IDText;
        private System.Windows.Forms.TextBox ValueText;
        private System.Windows.Forms.DateTimePicker DateFromDTP;
        private System.Windows.Forms.DateTimePicker DateToDTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}

