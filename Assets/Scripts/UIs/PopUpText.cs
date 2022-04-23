using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class PopUpText
{
    

    private static GameObject textPosition1;
    private static List<GameObject> textpositionsList;
    private static GameObject health; 

    public static GameObject TextPosition1
    {
        get => textPosition1;
        set => textPosition1 = value;
    }
    
    public static List<GameObject> TextpositionsList
    {
        get => textpositionsList;
        set => textpositionsList = value;
    }

    public static GameObject Health
    {
        get => health;
        set => health = value;
    }

    public static void Pop(string msg, GameObject position)
    {
        var text = position.GetComponent<TMP_Text>();
        text.text = msg;
    }
}
