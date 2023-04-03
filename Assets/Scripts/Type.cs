using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Type : MonoBehaviour
{
    [SerializeField] private InputActionProperty JoystickInput;
    private Vector2 inputDir;
    private Vector2 lastDir;
    private KeyPress key;
    private Transform tform;
    public  bool active;
    private bool tracking;

    private void Start()
    {
        tracking = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(active && !tracking)
        {
            inputDir = JoystickInput.action?.ReadValue<Vector2>() ?? Vector2.zero;
            if(inputDir.magnitude > 0.25)
            {
                // check if controller is pointed at key
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
                {
                    // get the key being pressed
                    key = hit.transform.gameObject.GetComponent<KeyPress>();
                    if (key == null) return;
                    tracking = true;
                    //depress key
                    tform = hit.transform;
                    tform.localPosition -= new Vector3(0f, 0.1f, 0.0f);
                    //start tracking keypress
                    StartCoroutine(TrackKeyPress());
                }
            }
        }
    }

    IEnumerator TrackKeyPress()
    {
        while(inputDir.magnitude > 0.25){
            inputDir = JoystickInput.action?.ReadValue<Vector2>() ?? Vector2.zero;
            if(inputDir.magnitude >= 0.25) lastDir = inputDir;
            yield return null;
        }

        //move the key back up 0.1 units locally
        tform.localPosition += new Vector3(0f, 0.1f, 0.0f);
        // ensure that the direction isn't "between" letters on the key
        if (lastDir.y == 1f) lastDir -= new Vector2(0.1f, 0.0f);
        else if (lastDir.y == -1f) lastDir += new Vector2(0.1f, 0.0f);
        else if (lastDir.x == 1f) lastDir += new Vector2(0.0f, 0.1f);
        else if (lastDir.x == -1f) lastDir -= new Vector2(0.0f, 0.1f);
        // type the key
        key.Type(lastDir);
        tracking = false;
        yield return null;
    }    
}
