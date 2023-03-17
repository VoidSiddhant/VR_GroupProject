using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputText;
    public GameObject keys;
    public GameObject caps;
    private bool capital;

    // Start is called before the first frame update
    void Start()
    {
        capital = false;
    }

    public void AddChar(string c)
    {
        inputText.text += c;
    }

    public void RemoveChar()
    {
        if(inputText.text.Length > 0)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }

    public void ToggleCaps()
    {
        capital = !capital; 
    }
}
