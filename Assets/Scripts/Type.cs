using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Type : MonoBehaviour
{
    private Vector2 inputDir;
    private KeyPress key;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // If joystick magnitude goes beyond 0.25
            // if raycast from that controller hits a key
                // store that key's KeyPress and transform component
                // move the key " down " 0.1 units locally
                // coroutine to track joystick direction while magnitude > 0.25
    }

    IEnumerator TrackKeyPress()
    {
        //while(<joystick vector2>.magnitude > 0.25){
            // inputDir = <get joystick input somehow>;
            // yield return null;
        // }

        //move the key back up 0.1 units locally
        key.Type(inputDir);
        yield return null;
    }    
}
