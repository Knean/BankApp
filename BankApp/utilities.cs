using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace BankApp
{
    static public class utilities
    {
        static public void printData()
        {
            MessageBox.Show("fuck");
        }

        static public List<Account> readData()
        {
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Account>));
            FileStream fs = new FileStream(System.Environment.CurrentDirectory +  "/file.xml", FileMode.Open);
            List<Account> accListOfDisk = (List<Account>)deSerializer.Deserialize(fs);
            fs.Close();
            return accListOfDisk;           
            
        }

        static public void storeData(List<Account> accounts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
            TextWriter writer = new StreamWriter(System.Environment.CurrentDirectory + "/file.xml");
            serializer.Serialize(writer, accounts);
            writer.Close();
        }

        static public void createData()
        {
            List<Account> accList = new List<Account>();            
            accList.Add(new Account("mario33", "password", "2324324lkjsd234", 5500, DateTime.Now));
            accList.Add(new Account("mario66", "password", "2324324lkjsd234", 5500, DateTime.Now));
            XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
            TextWriter writer = new StreamWriter(System.Environment.CurrentDirectory + "/file.xml");
            serializer.Serialize(writer, accList);

            writer.Close();
        }
    }
}
