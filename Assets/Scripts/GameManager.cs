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
        locomotion.transform.gameObject.SetActive(toggle);
        continuousTurn.transform.gameObject.SetActive(toggle);
        snapTurn.transform.gameObject.SetActive(toggle);
        dynamicMove.transform.gameObject.SetActive(toggle);
        teleportation.transform.gameObject.SetActive(toggle);
        if(toggle)
        {
            Vector3 pos = Player.Instance.transform.position;
            pos = pos + Player.Instance.transform.forward * keyboardDist;
            keyboard.transform.position = pos;
        }
    }
    
    public void SetAnnotation(GameObject go)
    {
        int childCount = go.transform.childCount;

        keyboard.SetAnnotation(go.GetComponent<TextMeshProUGUI>());
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
