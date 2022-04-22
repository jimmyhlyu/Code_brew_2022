using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace IO
{
    
    public class Sentence
    {
        public string Num;
        public string Content;
        public string Weight;
        public string URL;
<<<<<<< HEAD
=======

>>>>>>> bd9f974bd258b68e6877f11687ee47c9032a1b08
    }
    public static class ReadCsv
    {
        public static void ReadIO(List<Sentence> s)
        {
<<<<<<< HEAD
            string filePath = @"Assets/resource/text.csv";
=======
            string filePath = @"Assets/Resources/Test.csv";
>>>>>>> bd9f974bd258b68e6877f11687ee47c9032a1b08
            StreamReader reader = null;
            if (!File.Exists(filePath))
            {
                
                return;
            }

            
            reader = new StreamReader(File.OpenRead(filePath));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Sentence sen = new Sentence
                {
                    Num = values[0],
                    Content = values[1],
                    Weight = values[2],
                    URL = values[3]
                };

                s.Add(sen);
            }
        }


        public static void WriteIO(List<Sentence> sen)
        {
            string strFilePath = @"Assets/resource/text.csv";
            //string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();
            
            int ilength = sen.Count;
            //Debug.Log(ilength);
            for (int i = 0; i < ilength; i++)
            {
                sbOutput.AppendLine(string.Join(",", sen[i].Num,sen[i].Content,sen[i].Weight,sen[i].URL));
            }
            File.WriteAllText(strFilePath, sbOutput.ToString());
            
            
        }
    }
}

        
    

            
        
    

