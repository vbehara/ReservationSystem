using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RailwayReservation
{
    /// <summary>
    /// This class is used to serialize the 
    /// </summary>
    public class ReservationSerializer
    {
        /// <summary>
        /// Method to serialize the booked ticket infomation of the customer
        /// </summary>
        /// <param name="fileName">File Name</param>
       /// <param name="ticket">Ticket object to serialize</param>
        public void Serialize(string fileName,Ticket ticket)
        {
            XmlSerializer xs = new XmlSerializer(typeof( Ticket));
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // Serializing the object with a xml serializer
            try
            {
                xs.Serialize(fs,ticket);
            }
            catch (XmlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            fs.Close();
            Console.WriteLine("File created");
        }

        /// <summary>
        ///  Method to deserialize the booked ticket information of the customer
        /// </summary>
        /// <param name="xmlFile">XML File path</param>
        /// <returns></returns>
        public Ticket DeSerialize(string xmlFile)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Ticket));
            FileStream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read);
            // DeSerializing the object with a xml serializer
            Ticket ticket = (Ticket)xs.Deserialize(fs);
            fs.Close();
            return ticket;
        }
    }
}
