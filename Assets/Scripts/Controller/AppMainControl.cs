using System.Collections;
using System.Collections.Generic;
using IO;
using UnityEngine;

public class AppMainControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Sentence> Sentences = new List<Sentence>();
    void Start()
    {
        
        ReadCsv.ReadIO(Sentences);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
