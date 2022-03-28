using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xmlcontent;
using System.IO;
using System.Xml.Serialization;

namespace AdminAPP
{
    internal class AdminAPPman
    {
        public Baza content;
        private string strPath;
        XmlSerializer serializer;

        public AdminAPPman()
        {
            strPath = $"C:\\Users\\ICG-Engineering\\Desktop\\DATA.xml"; 
            serializer = new XmlSerializer(typeof(Baza));
        }

        public void read()
        {
            using  (Stream reader = new FileStream(strPath, FileMode.Open))
            {
                content = (Baza)serializer.Deserialize(reader);
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
