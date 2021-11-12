using System;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AddressBook
{
    class ReadWriteCSV
    {
        public class AddressData
        {
            public string name { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
        }

        public static void csvReadWrite()
        {
            string importPath= @"C:\Users\Mehta\source\AddressBook\AddressBook\addressBook.csv";
            string exportPath = @"C:\Users\Mehta\source\AddressBook\AddressBook\contactList.csv";
            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Contacts: ");
               
                int count = 1;
                foreach (var contact in records)
                {
                   
                    Console.WriteLine(count+".  "+contact.name+"\t" + contact.phone+ "\t" + contact.email+ "\t" + contact.address
                                  + "\t" + contact.city+ "\t" + contact.state+ "\t" + contact.zip);
                    count++;
                }

                using (var writer = new StreamWriter(exportPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
         
    }
}



