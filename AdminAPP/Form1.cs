using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminAPP
{
    public partial class Form1 : Form
    {
        AdminAPPman configs;

        int indexModules;
        int indexFields;
        int indexParameters;
        bool changenotsave;
        bool blockcontrolread;

        public Form1()
        {
            InitializeComponent();

            changenotsave = false;
            blockcontrolread = false;
            configs = new AdminAPPman();
            configs.read();
            if (configs.content != null)
            {
                foreach (xmlcontent.BazaModule element in configs.content.Module)
                {
                    Modules.Items.Add(element.name);
                }
            }

            string[] combovalues = { "number", "string", "boolean" };
            comboBoxType.Items.AddRange(combovalues);
        }

        private void ClearParametersFields()
        {
            IDText.Clear();
            ValueText.Clear();
            DateFromDTP.Value = DateTime.Now;
            DateToDTP.Value = DateTime.Now;
            ValueText.ReadOnly = true;
            DateFromDTP.Enabled = false;
            DateToDTP.Enabled = false;
            comboBoxType.SelectedIndex = -1;
            this.SaveButton.Enabled = false;
        }
        private void SaveParamChanged()
        {

            //xmlcontent.BazaModuleFieldParameter parameter = new xmlcontent.BazaModuleFieldParameter();
            if (blockcontrolread)
            {
                return;
            }
            changenotsave = true;
            xmlcontent.BazaModuleFieldParameter parameter_reference = configs.content.Module[indexModules].Field[indexFields].Parameter[indexParameters];
            parameter_reference.Modified = true;
            //parameter.ID = (uint)Int32.Parse(IDText.Text);
            parameter_reference.VALUE = ValueText.Text;
            parameter_reference.DateFrom = DateFromDTP.Text;
            parameter_reference.DateTo = DateToDTP.Text;
            //parameter_reference.name = configs.content.Module[indexModules].Field[indexFields].Parameter[indexParameters].name;

            if (comboBoxType.SelectedIndex == 1)
                parameter_reference.Type = "string";
            else if (comboBoxType.SelectedIndex == 0)
                parameter_reference.Type = "number";
            else if (comboBoxType.SelectedIndex == 2)
                parameter_reference.Type = "boolean";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModuleItemChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Modules.SelectedValue);
        }


        private void ModuleIndexChange(object sender, EventArgs e)
        {
            blockcontrolread = true;
            indexModules = Modules.SelectedIndex;
            if (indexModules == -1)
                return;
            ClearParametersFields();
            Fields.Items.Clear();
            Parameters.Items.Clear();
            xmlcontent.BazaModule module = configs.content.Module[indexModules];
            foreach (xmlcontent.BazaModuleField field in module.Field)
            {
                Fields.Items.Add(field.name);
            }
            blockcontrolread = false;
        }

        private void SelectedIndexFields(object sender, EventArgs e)
        {
            blockcontrolread = true;
            indexFields = Fields.SelectedIndex;
            if (indexFields == -1)
                return;
            ClearParametersFields();
            Parameters.Items.Clear();
            xmlcontent.BazaModuleField field = configs.content.Module[indexModules].Field[indexFields];
            foreach (xmlcontent.BazaModuleFieldParameter parameter in field.Parameter)
            {
                Parameters.Items.Add(parameter.name);
            }
            blockcontrolread = false;
        }

        private void SelectedIndexParameters(object sender, EventArgs e)
        {
            blockcontrolread = true;
            indexParameters = Parameters.SelectedIndex;
            if (indexParameters == -1)
                return;
            ClearParametersFields();
            
            xmlcontent.BazaModuleFieldParameter parameter = configs.content.Module[indexModules].Field[indexFields].Parameter[indexParameters];
            IDText.Text = parameter.ID.ToString();
            ValueText.Text = parameter.VALUE;
            ValueText.ReadOnly = false;
            DateFromDTP.Text = parameter.DateFrom;
            DateFromDTP.Enabled = true;
            DateToDTP.Text = parameter.DateTo;
            DateToDTP.Enabled = true;

            if (parameter.Type.Trim() == "string")
                comboBoxType.SelectedIndex = 1;
            else if (parameter.Type.Trim() == "number")
                comboBoxType.SelectedIndex = 0;
            else if (parameter.Type.Trim() == "boolean")
                comboBoxType.SelectedIndex = 2;
                
            comboBoxType.Enabled = true;
            this.SaveButton.Enabled = true;
            blockcontrolread = false;
        }

        private void OnAdd(object sender, EventArgs e)
        {

        }

        private void OnSave(object sender, EventArgs e)
        {
            changenotsave = false;
            configs.write();
            DialogResult sus = MessageBox.Show("Information was saved!!!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TextChanged(object sender, EventArgs e)
        {
            SaveParamChanged();
        }

        private void TypeChange(object sender, EventArgs e)
        {
            SaveParamChanged();
        }

        private void DateFromChange(object sender, EventArgs e)
        {
            SaveParamChanged();
        }

        private void DateToChange(object sender, EventArgs e)
        {
            SaveParamChanged();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (changenotsave)
            {
                DialogResult sus = MessageBox.Show("Do you want to save the data before closing?", "STOP", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sus == DialogResult.Yes)
                {
                    configs.write();
                }
                else if (sus == DialogResult.No)
                {
                    // Close and change nothing
                }
                else if (sus == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
