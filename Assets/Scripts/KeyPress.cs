using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
    [SerializeField]private Keyboard keyboard;
    [SerializeField]private string keyName;
    [TextArea][SerializeField]private string char_override;
    private int num_chars;
    private TextMeshProUGUI text;
    private string chars;

    // Start is called before the first frame update
    void Start()
    {
        num_chars = 0;
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (keyName.Length >= 1)
        {
            text.text = keyName;
            chars = char_override;
        }
        else
        {
            for (int i = 0; i < this.name.Length; i++)
            {
                // check if a newline should be entered
                if (num_chars > 0 && num_chars % 2 == 0) text.text += '\n';
                // check if space should be entered
                else if (num_chars > 0) text.text += " ";

                // check if name of key should not be used as typable characters
                if (char_override.Length != 0)
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
        }
    }

    public void Type(Vector2 input)
    {
        Debug.Log(input.x + " " + input.y);

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
