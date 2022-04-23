
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using IO;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Unity.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class PopUpTextAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textPosition1;
    public GameObject textPositionList1;
    public GameObject textPositionList2;
    public GameObject textPositionList3;
    public GameObject textPositionList4;
    public GameObject textPositionList5;
    public PauseInfo pauseInfo;
    public GameObject TextPosition1 => textPosition1;
    public GameObject TextPositionList1 => textPositionList1;
    public GameObject TextPositionList2 => textPositionList2;
    public GameObject TextPositionList3 => textPositionList3;
    public GameObject TextPositionList4 => textPositionList4;
    public GameObject TextPositionList5 => textPositionList5;
    public RawImage Earth;
    public Texture happyEarth;
    public Texture sadEarth;
    public GameObject Health;

    private string acturalString = "";
    private static string finalString;
    private int index;
    private static bool  count = false;
    public Button nextButton;
    public static List<Sentence> Sentences;




    private void OnEnable()
    {
        PopUpText.TextPosition1 = textPosition1;
        PopUpText.TextpositionsList = new List<GameObject>();
        PopUpText.TextpositionsList.Add(textPositionList1);
        PopUpText.TextpositionsList.Add(textPositionList2);
        PopUpText.TextpositionsList.Add(textPositionList3);
        PopUpText.TextpositionsList.Add(textPositionList4);
        PopUpText.TextpositionsList.Add(textPositionList5);
        PopUpText.Health = Health;
    }

    public static void Try()
    {
        
        Debug.Log("pressed");

    }

    private void Start()
    {
        Sentences = AppMainControl.Sentences;
        int position = 0;
        int weightSum = 0;
        foreach (var sentence in Sentences)
        {
            if (sentence.URL.Length > 4)
            {
                int weight = Convert.ToInt32(sentence.Weight);
                byte offset = Convert.ToByte(math.abs(weight) * 50) ;
                if (weight > 0)
                {
                    var color = PopUpText.TextpositionsList[position].GetComponent<TMP_Text>();
                    color.faceColor = new Color32(offset, 0, 0 ,255);
                    color.SetMaterialDirty();
                }
                if (weight < 0)
                {
                    var color = PopUpText.TextpositionsList[position].GetComponent<TMP_Text>();
                    color.faceColor = new Color32(0, offset, 0 ,255);
                    color.SetMaterialDirty();
                }

                weightSum += weight;
                PopUpText.Pop(sentence.title, PopUpText.TextpositionsList[position]);
                position += 1;
            }

            float healthValue = 78 - weightSum * 0.01f;
            string healthText = "The earth's 'health' is in [" + healthValue + "%] today. " +
                                "\n In this trend, it is estimated to become Zero in [357] years";
            PopUpText.Pop(healthText, PopUpText.Health);
        }
        
    }

    private static int countForSentence = 0; 
    private void Update()
    {
        nextButton.onClick.AddListener(Count);
        
        
        if (count && countForSentence < Sentences.Capacity-1)
        {
            countForSentence += 1; 
            acturalString = "";
            index = 0;
            
            if (Convert.ToInt32(Sentences[countForSentence].Weight) > 0)
            {
                Earth.texture = happyEarth;
            }
            else
            {
                Earth.texture = sadEarth;
            }
            
            PopText(Sentences[countForSentence].Content);
            
            
            count = false;
            
        }
    }

    public static void OpenURl()
    {
        if (countForSentence > Sentences.Capacity - 1)
        {
            return;
        }
        Application.OpenURL(Sentences[countForSentence].URL);
        
    }

    public static void Count()
    {
        count = true; 
    }
    
    private void PopText(string String)
    {
        finalString = String;
        ReproduceText();
    }

    private void ReproduceText()
    {
        //if not readied all letters
        if (index < finalString.Length)
        {
            //get one letter
            char letter = finalString[index];

            //Actualize on screen
            PopUpText.Pop(Write(letter),textPosition1);

            //set to go to the next
            index += 1;
            StartCoroutine(PauseBetweenChars(letter));
        }
    }

    private string Write(char letter)
    {
        acturalString += letter;
        return acturalString;
    }

    private IEnumerator PauseBetweenChars(char letter)
    {
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(pauseInfo.dotPause);
                ReproduceText();
                yield break;
            case ',':
                yield return new WaitForSeconds(pauseInfo.commaPause);
                ReproduceText();
                yield break;
            case ' ':
                yield return new WaitForSeconds(pauseInfo.spacePause);
                ReproduceText();
                yield break;
            default:
                yield return new WaitForSecondsRealtime(pauseInfo.normalPause);
                ReproduceText();
                yield break;
        }
    }
}

[Serializable]
public class PauseInfo
{
    public float dotPause;
    public float commaPause;
    public float spacePause;
    public float normalPause;
}

