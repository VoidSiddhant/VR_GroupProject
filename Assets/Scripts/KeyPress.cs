using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
    Keyboard keyboard;
    public char[] char_override;
    private int num_chars;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        num_chars = 0;
        text = GetComponentInChildren<TextMeshProUGUI>();
        for(int i = 0; i < this.name.Length; i++)
        {
            if (num_chars > 0 && num_chars % 2 == 0) text.text += '\n';

            if (i < char_override.Length) text.text += char_override[i];
            else text.text += this.name[i];

            num_chars++;

        }
    }


}
