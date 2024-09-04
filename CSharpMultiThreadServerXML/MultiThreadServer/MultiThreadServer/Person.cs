using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MultiThreadServer
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = String.Empty;
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void FromXML(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                using (XmlReader reader = XmlReader.Create(sr))
                {
                    reader.ReadStartElement("person");
                    Name = reader.ReadElementContentAsString("name", "");
                    Age = reader.ReadElementContentAsInt("age", "");
                    reader.ReadEndElement();
                }
            }
        }

        public String ToXML()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    writer.WriteStartElement("person");
                    writer.WriteElementString("name", Name);
                    writer.WriteElementString("age", Age.ToString());
                    writer.WriteEndElement();
                }

                return sw.ToString();
            }
        }
    }
}