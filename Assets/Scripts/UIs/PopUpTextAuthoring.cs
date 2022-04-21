
using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class PopUpTextAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textPosition1;

    public GameObject TextPosition1 => textPosition1;

    private string outputLetters;
    private void OnEnable()
    {
        PopUpText.TextPosition1 = textPosition1;
    }
    

}
