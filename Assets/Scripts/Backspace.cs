using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backspace : KeyPress
{
    public override void Type(Vector2 input)
    {
        keyboard.RemoveChar();
    }
}
