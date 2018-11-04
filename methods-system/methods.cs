using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;

namespace methods_system
{
    public class methods
    {

        public static string retourchariot()
        {
            string X = Environment.NewLine;
            return X;
        }
    }

    public class XMLwrite
    {
    public class Book
        {
        public String title;
        }

    public static void WriteXML()
        {
        Book overview = new Book();
        overview.title = "Serialization Overview";
        XmlSerializer writer =  new XmlSerializer(typeof(Book));

            // System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "//SerializationOverview.xml";
        FileStream file = File.Create(path);
        
        writer.Serialize(file, overview);
        file.Close();
        }

        public void ReadXML()
        {
            // First write something so that there is something to read ...  
            var b = new Book { title = "Serialization Overview" };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
            var wfile = new StreamWriter(@"c:\temp\SerializationOverview.xml");
            writer.Serialize(wfile, b);
            wfile.Close();

            // Now we can read the serialized book ...  
            XmlSerializer reader = new XmlSerializer(typeof(Book));
            StreamReader file = new System.IO.StreamReader(
                @"c:\temp\SerializationOverview.xml");
            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.title);
            Thread.Sleep(2000);
        }

    }
}  

