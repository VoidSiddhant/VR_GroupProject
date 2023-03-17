using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
    [SerializeField]Keyboard keyboard;
    public char[] char_override;
    private int num_chars;
    public TextMeshProUGUI text;
    private string chars;

    // Start is called before the first frame update
    void Start()
    {
        num_chars = 0;
        text = GetComponentInChildren<TextMeshProUGUI>();
        for(int i = 0; i < this.name.Length; i++)
        {
            if (num_chars > 0 && num_chars % 2 == 0) text.text += '\n';

            if (i < char_override.Length)
            {
                text.text += char_override[i];
                chars += char_override[i];
            }
            else
            {
                text.text += this.name[i];
                chars += this.name[i];
            }
            num_chars++;

        }

        Type(new Vector2(0.8f, 0.2f));

    }

    public void Type(Vector2 input)
    {
        // If there is only one letter on the key, print that letter
        if (chars.Length == 1) 
            keyboard.AddChar(chars.Substring(0, 1));
        //if there are two letters on the key, decide whether to print the left or the right one 
        else if (chars.Length == 2)
        {
            if (input.x < 0) keyboard.AddChar(chars.Substring(0, 1));
            else if(input.x > 0) keyboard.AddChar(chars.Substring(1,1));
        }
        // if there are three letters on the key, print either the top left, top right, or bottom letter
        else if (chars.Length == 3) 
        {
            if (input.y > 0 && input.x < 0) keyboard.AddChar(chars.Substring(0, 1));
            else if (input.y > 0 && input.x > 0) keyboard.AddChar(chars.Substring(1, 1));
            else if (input.y < 0) keyboard.AddChar(chars.Substring(2, 1));
        }
        // if there are four letters on the key, print either the top left, top right, bottom left, or bottom right letter
        else if (chars.Length == 4)
        {
            if (input.y > 0 && input.x < 0) keyboard.AddChar(chars.Substring(0, 1));
            else if (input.y > 0 && input.x > 0) keyboard.AddChar(chars.Substring(1, 1));
            else if (input.y < 0 && input.x < 0) keyboard.AddChar(chars.Substring(2, 1));
            else if (input.y < 0 && input.x > 0) keyboard.AddChar(chars.Substring(3, 1));
        }

    }


}
