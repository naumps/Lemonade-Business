using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LemonadeB_1
{
    public class ObjectSerialization
    {
        public static void saveToFile(Store store)
        {
            using(FileStream stream = File.Create("serialization.bin"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, store);
            }
        }


        public static Store readFromFile()
        {

            Store store = null;
            using (FileStream stream = File.OpenRead("serialization.bin"))
            {
              
                BinaryFormatter formatter = new BinaryFormatter();
                store =(Store) formatter.Deserialize(stream);

            }
            return store;
        }


    }
}
