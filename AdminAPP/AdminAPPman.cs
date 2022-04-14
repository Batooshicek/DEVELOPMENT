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
using System.Data.OracleClient;
using System.Collections.Generic;
using Oracle.DataAccess;
using Oracle.ManagedDataAccess;

namespace AdminAPP
{
    internal class AdminAPPman
    {
        public Baza content;
        private string strPath;
        XmlSerializer serializer;
        OracleConnection conn;
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

                if (Convert.ToBoolean(appSettings["UseDBInsteadOfXML"]) == true )
                {
                    OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
                        
                    conn = new OracleConnection();
                    ocsb.Password = appSettings["Password"];
                    ocsb.UserID = appSettings["UserID"];
                    ocsb.DataSource = appSettings["DataSource"];
                    conn.ConnectionString = ocsb.ConnectionString;
                    conn.Open();
                }
                else
                {
                    serializer = new XmlSerializer(typeof(Baza));
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Config could not be read", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Value of UseDBInsteadOfXML is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ~AdminAPPman()
        {
        }

        public void read()
        {
            if (Convert.ToBoolean(appSettings["UseDBInsteadOfXML"]))
            {
                readDB();
            }
            else
            {
                readXML();
            }
        }

        public void write()
        {
            if (Convert.ToBoolean(appSettings["UseDBInsteadOfXML"]))
            {
                writeDB();
            }
            else
            {
                writeXML();
            }
        }

        private void readDB()
        {
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "Select * from configurations order by MODULE, FIELD"; // In loc de * -> denumirile coloanelor
                OracleDataReader reader = cmd.ExecuteReader();

                content = new Baza();
                content.Module = new List<BazaModule>();
                string LastNameModule = "";
                string LastNameField = "";

                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string MODULE = reader.GetString(1);
                    string FIELD = reader.GetString(2);
                    string PARAMETER = reader.GetString(3);
                    //DateTime DateFrom = reader.GetDateTime(4);
                    var DateFromConverted = reader.GetValue(4);
                    string DateFrom = Convert.ToString(DateFromConverted);

                    //DateTime DateTo = reader.GetDateTime(5);
                    var DateToConverted = reader.GetValue(5);
                    string DateTo = Convert.ToString(DateToConverted);

                    //string Value = reader.GetString(6);
                    var ValueConverted = reader.GetValue(6);
                    string Value = Convert.ToString(ValueConverted);

                    //string Type = reader.GetString(7);
                    var TypeConverted = reader.GetValue(7);
                    string Type = Convert.ToString(TypeConverted);

                    

                    BazaModuleFieldParameter NewParameter = new BazaModuleFieldParameter();
                    NewParameter.ID = Convert.ToUInt32(ID);
                    NewParameter.name = PARAMETER;
                    NewParameter.DateFrom = DateFrom;
                    NewParameter.DateTo = DateTo;
                    NewParameter.VALUE = Value;
                    NewParameter.Type = Type;

                    BazaModuleField NewField = new BazaModuleField();
                    NewField.Parameter = new List<BazaModuleFieldParameter>();
                    NewField.Parameter.Add(NewParameter);
                    NewField.name = FIELD;

                    BazaModule NewModule = new BazaModule();
                    NewModule.Field = new List<BazaModuleField>();
                    NewModule.name = MODULE;

                    if (NewModule.name != LastNameModule)
                    {
                        content.Module.Add(NewModule);
                        NewModule.Field.Add(NewField);
                        LastNameField = NewField.name;
                        LastNameModule = NewModule.name;
                    }
                    else
                    {
                        if (NewField.name != LastNameField)
                        {
                            content.Module.Last().Field.Add(NewField);
                            LastNameField = NewField.name;
                        }
                        else
                        {
                            content.Module.Last().Field.Last().Parameter.Add(NewParameter);
                        }
                    }
                }
            }
        }

        private void writeDB()
        {
            using (OracleCommand cmd = conn.CreateCommand())
            {
                foreach (xmlcontent.BazaModule modul in content.Module)
                {
                    foreach (xmlcontent.BazaModuleField field in modul.Field)
                    {
                        foreach (xmlcontent.BazaModuleFieldParameter parameter in field.Parameter)
                        {
                            if (parameter.Modified == true)
                            {
                                OracleParameter datefrom = new OracleParameter("datefrom", parameter.DateFrom);
                                OracleParameter dateto = new OracleParameter("dateto", parameter.DateTo);
                                OracleParameter value = new OracleParameter("value", parameter.VALUE);
                                OracleParameter type = new OracleParameter("type", parameter.Type);
                                OracleParameter ID = new OracleParameter("ID", parameter.ID);

                                cmd.Parameters.Add(datefrom);
                                cmd.Parameters.Add(dateto);
                                cmd.Parameters.Add(value);
                                cmd.Parameters.Add(type);
                                cmd.Parameters.Add(ID);

                                cmd.CommandText = "UPDATE configurations SET datefrom = to_date(:datefrom,'DD/MM/YYYY'), dateto = to_date(:dateto,'DD/MM/YYYY'), VALUE = :value, TYPE = :type WHERE ID = :ID";
                                cmd.ExecuteNonQuery();
                            }
                            parameter.Modified = false;
                        }
                    }
                }
            }
        }

        private void readXML()
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

        private void writeXML()
        {
            using (Stream reader = new FileStream(strPath, FileMode.Create))
            {
                serializer.Serialize(reader, content);
            }
        }
    }
}
