using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnnotation : KeyPress
{
    public override void Type(Vector2 input)
    {
        if (input.y > 0)
        {
            keyboard.SaveString();
        }

        GameManager.Instance.ToggleKeyboard(false);
    }
}
