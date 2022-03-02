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
        public void read()
        {
            string          strPath     = $"C:\\Users\\ICG-Engineering\\Desktop\\DATA.xml";
            XmlSerializer   serializer  = new XmlSerializer(typeof(Baza));

            using  (Stream reader = new FileStream(strPath, FileMode.Open))
            {
                content = (Baza)serializer.Deserialize(reader);
            }
        }
    }
}
