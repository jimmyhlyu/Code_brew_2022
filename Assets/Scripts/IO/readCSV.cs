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
        public string yes;
        public string no;
        public string title;

    }
    public static class ReadCsv
    {
        public static void ReadIO(List<Sentence> s)
        {
            string filePath = @"Assets/Resources/Test.csv";
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
                    URL = values[3],
                    yes = values[4],
                    no = values[5],
                    title = values[6]
                };

                s.Add(sen);
            }
        }


        public static void WriteIO(List<Sentence> sen)
        {
            string strFilePath = @"C:\Users\rolli\OneDrive\Desktop\text.csv";
            //string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();
            
            int ilength = sen.Count;
            Debug.Log(ilength);
            for (int i = 0; i < ilength; i++)
            {
                sbOutput.AppendLine(string.Join(",", sen[i].Num,sen[i].Content,sen[i].Weight,sen[i].URL));
            }
            File.WriteAllText(strFilePath, sbOutput.ToString());
            
            
        }
    }
}

        
    

            
        
    

