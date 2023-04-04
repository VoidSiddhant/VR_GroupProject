using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsLock : KeyPress
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Type(Vector2 input)
    {

        if(keyboard == null) {
            Debug.Log("keyboard null");
            return;
        }

        keyboard.ToggleCaps(); 
    }
}
