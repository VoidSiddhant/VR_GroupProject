using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    public Keyboard keyboard;
    [SerializeField]private float keyboardDist;

    [SerializeField] private float maxDist;

    [Header("UI Objects")]
    public GameObject inventoryUI;

    // for disabling/enabling joystick movement
    private GameObject XR_Origin;
    private LocomotionSystem locomotion;
    private ActionBasedContinuousTurnProvider continuousTurn;
    private ActionBasedSnapTurnProvider snapTurn;
    private DynamicMoveProvider dynamicMove;
    private TeleportationProvider teleportation;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(instance);
        }



        locomotion = GameObject.FindObjectOfType<XROrigin>().GetComponent<LocomotionSystem>();
        continuousTurn = GameObject.FindObjectOfType<XROrigin>().GetComponent<ActionBasedContinuousTurnProvider>();
        snapTurn = GameObject.FindObjectOfType<XROrigin>().GetComponent<ActionBasedSnapTurnProvider>();
        dynamicMove = GameObject.FindObjectOfType<XROrigin>().GetComponent<DynamicMoveProvider>();
        teleportation = GameObject.FindObjectOfType<XROrigin>().GetComponent<TeleportationProvider>();
    }

    public void ToggleKeyboard(bool toggle)
    {
        Debug.Log("Toggling keyboard");
        keyboard.transform.gameObject.SetActive(toggle);
        locomotion.enabled = (!toggle);
        continuousTurn.enabled = (!toggle);
        snapTurn.enabled = (!toggle);
        dynamicMove.enabled = (!toggle);
        teleportation.enabled = (!toggle);
        if(toggle)
        {
            Vector3 pos = Player.Instance.transform.position;
            // direction to move keyboard out from player
            Vector3 dir = Player.Instance.transform.forward;
            dir.y = 0;
            dir.Normalize();

            // get height keyboard should be at
            RaycastHit hit;
            if (Physics.Raycast(Player.Instance.transform.position, -Player.Instance.transform.up, out hit, Mathf.Infinity))
            {
                pos.y = (hit.point.y + pos.y)/2.0f ;
            }
            // move keyboard
            keyboard.transform.position = pos + dir * keyboardDist;
            // point keyboad back toward player
            keyboard.transform.LookAt(pos);
        }
    }
    
    public void SetAnnotation(TextMeshProUGUI go)
    {
        keyboard.SetAnnotation(go);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyboard != null && keyboard.transform.gameObject.activeSelf)
        {
            float dist = Vector2.Distance(new Vector2(Player.Instance.transform.position.x, Player.Instance.transform.position.z), new Vector2(keyboard.transform.position.x, keyboard.transform.position.z));
            if (dist > maxDist) 
            {
                keyboard.SaveString();
                keyboard.Close();
                ToggleKeyboard(false);
            }
         }
    }
}
