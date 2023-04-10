using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    public static Player Instance{ get { return instance; } }

    public bool isEnableInventory = true;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnableInventory)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                GameManager.Instance.inventoryUI.SetActive(!GameManager.Instance.inventoryUI.activeSelf);
                Vector3 point = transform.position + transform.forward * 4f;
                point.y = 2.0f;
                GameManager.Instance.inventoryUI.transform.position = point;
                GameManager.Instance.inventoryUI.transform.LookAt(transform);
            }
        }
    }
}
