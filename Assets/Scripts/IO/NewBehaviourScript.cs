using System.Collections.Generic;
using UnityEngine;

namespace IO
{
    
    public class NewBehaviourScript : MonoBehaviour
    {
        private List<Sentence> sentences = new List<Sentence>();
        
        void Start()
        {
            ReadTest();
            //WriteTest();
        }

        public void ReadTest()
        {
            ReadCsv.ReadIO(sentences);
            foreach (var coloumn1 in sentences){
                Debug.Log(coloumn1.Num +"  "+coloumn1.Content+" "+coloumn1.Weight+" "+coloumn1.URL);
            }
        }

        public void WriteTest()
        {
            Sentence s = new Sentence();
            s.Num = "6";
            s.Content = "hello";
            s.Weight = "2";
            s.URL = "www.wqdqw.com";
            sentences.Add(s);
            Sentence s2 = new Sentence();
            s2.Num = "9";
            s2.Content = "bye bye";
            s2.Weight = "7";
            s2.URL = "www.132312.com";
            sentences.Add(s2);
            
            ReadCsv.WriteIO(sentences);
            
        }

    }
}
