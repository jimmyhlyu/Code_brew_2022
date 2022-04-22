using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class PopUpText
{
    private static GameObject textPosition1;

    public static GameObject TextPosition1
    {
        get => textPosition1;
        set => textPosition1 = value;
    }

    public static void Pop(string msg)
    {
        var text = textPosition1.GetComponent<TMP_Text>();
        text.text = msg;
    }
}
