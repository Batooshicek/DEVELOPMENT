using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xmlcontent;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Windows.Forms;

namespace AdminAPP
{
    internal class AdminAPPman
    {
        public Baza content;
        private string strPath;
        XmlSerializer serializer;
        NameValueCollection appSettings;

        public AdminAPPman()
        {
            try
            {
                appSettings = ConfigurationManager.AppSettings;
                if ( appSettings.Count == 0 )
                {
                    throw new ConfigurationErrorsException();
                }
                strPath = appSettings["XMLPath"];
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Config could not be read", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            //strPath = $"C:\\Users\\ICG-Engineering\\Desktop\\DATA.xml"; 
            serializer = new XmlSerializer(typeof(Baza));
        }

        public void read()
        {
            using  (Stream reader = new FileStream(strPath, FileMode.Open))
            {
                content = (Baza)serializer.Deserialize(reader);
            }

            foreach (xmlcontent.BazaModule modul in content.Module)
            {
                foreach (xmlcontent.BazaModuleField field in modul.Field)
                {
                    foreach (xmlcontent.BazaModuleFieldParameter parameter in field.Parameter)
                    {
                        parameter.VALUE = parameter.VALUE.Trim();
                        parameter.Type = parameter.Type.Trim();
                        parameter.DateTo = parameter.DateTo.Trim();
                        parameter.DateFrom = parameter.DateFrom.Trim();
                    }
                }
            }

        }
        public void write()
        {
            using (Stream reader = new FileStream(strPath, FileMode.Create))
            {
                serializer.Serialize(reader, content);
            }
        }
    }
}
