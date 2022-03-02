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

        public Form1()
        {
            InitializeComponent();

            configs = new AdminAPPman();
            configs.read();

            foreach (xmlcontent.BazaModule element in configs.content.Module)
            {
                Modules.Items.Add(element.name);
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

        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void ModuleIndexChange(object sender, EventArgs e)
        {
            indexModules = Modules.SelectedIndex;

            ClearParametersFields();
            Fields.Items.Clear();
            Parameters.Items.Clear();
            xmlcontent.BazaModule module = configs.content.Module[indexModules];
            foreach (xmlcontent.BazaModuleField field in module.Field)
            {
                Fields.Items.Add(field.name);
            }
        }

        private void SelectedIndexFields(object sender, EventArgs e)
        {
            indexFields = Fields.SelectedIndex;

            ClearParametersFields();
            Parameters.Items.Clear();
            xmlcontent.BazaModuleField field = configs.content.Module[indexModules].Field[indexFields];
            foreach (xmlcontent.BazaModuleFieldParameter parameter in field.Parameter)
            {
                Parameters.Items.Add(parameter.name);
            }

        }

        private void SelectedIndexParameters(object sender, EventArgs e)
        {
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

        }
    }
}
