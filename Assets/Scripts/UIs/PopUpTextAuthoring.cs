
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using Unity.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class PopUpTextAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textPosition1;
    public PauseInfo pauseInfo;
    public GameObject TextPosition1 => textPosition1;
    private string acturalString = "";
    private static string finalString;
    private int index;
    public Button button;
    
    private void OnEnable()
    {
        PopUpText.TextPosition1 = textPosition1;
        
    }

    public static void Try()
    {
        finalString = ("fkyea");
        Debug.Log("pressed");

    }

    private void Start()
    {
        PopText("helloworld");
    }

    private void Update()
    {
        Start();
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
            PopUpText.Pop(Write(letter));

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

