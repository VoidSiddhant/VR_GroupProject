using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Keyboard : MonoBehaviour
{
    // for disabling/enabling joystick movement
    [SerializeField] private GameObject XR_Origin;
    private LocomotionSystem locomotion;
    private ActionBasedContinuousTurnProvider continuousTurn;
    private ActionBasedSnapTurnProvider snapTurn;
    private DynamicMoveProvider dynamicMove;
    private TeleportationProvider teleportation;


    public TextMeshProUGUI inputText;
    public TextMeshProUGUI note;
    private bool untouched;
    private bool capital;

    // Start is called before the first frame update
    void Start()
    {
        capital = false;

        locomotion = XR_Origin.GetComponent<LocomotionSystem>();
        continuousTurn = XR_Origin.GetComponent<ActionBasedContinuousTurnProvider>();  
        snapTurn = XR_Origin.GetComponent<ActionBasedSnapTurnProvider>();
        dynamicMove = XR_Origin.GetComponent<DynamicMoveProvider>();
        teleportation = XR_Origin.GetComponent<TeleportationProvider>();
    }

    public void AddChar(string c)
    {
        

        if (capital) inputText.text += c.ToUpper();
        else if (!capital) inputText.text += c.ToLower();
    }

    public void RemoveChar()
    {
        if(inputText.text.Length > 0)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }

        if(inputText.text.Length == 0) { 
            inputText.text = "";
        }
    }

    public void ToggleCaps()
    {
        capital = !capital; 
    }

    public void LoadString()
    {
        if (note == null) 
        {
            Debug.Log("Load failed, note is null");
            return; 
        }
        inputText.text = note.text;
    }

    public void SaveString() 
    { 
        if (note == null)
        {
            Debug.Log("Save failed, note is null");
            return;
        }
        note.text = inputText.text;
    }

    public void Close()
    {
        // get rid of the reference
        note = null;
        inputText.text = "";
    }

    public void SetAnnotation(TextMeshProUGUI textmesh)
    {
        if (textmesh == null)
        {
            Debug.Log("set annotation failed, textmesh is null");
            return;
        }
        note = textmesh;
    }
}
