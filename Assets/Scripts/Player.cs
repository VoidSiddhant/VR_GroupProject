using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    public static Player Instance{ get { return instance; } }

    public bool isEnableInventory = true;

    public Transform raycastPoint;

    public bool enableMeasureTool = false;
    public LayerMask measureToolLayer;

    public Vector3 measurePinAPos,measurePinBPos;
    public GameObject measurePinPrefab;

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


        if(enableMeasureTool)
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(raycastPoint.transform.position, raycastPoint.transform.forward * -1.0f);
            Debug.DrawRay(ray.origin, ray.direction * 10.0f,Color.red);
            if(Physics.Raycast(ray,out hitInfo, 10.0f,measureToolLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10.0f,Color.green);

                if(Input.GetMouseButtonDown(0))
                {
                    if (measurePinAPos.magnitude <= 0 && measurePinBPos.magnitude <= 0)
                    {
                        measurePinAPos = hitInfo.point;
                        Instantiate(measurePinPrefab, measurePinAPos, Quaternion.identity);
                    }
                    else if (measurePinAPos.magnitude > 0 && measurePinBPos.magnitude <= 0)
                    {
                        measurePinBPos = hitInfo.point;
                        Instantiate(measurePinPrefab, measurePinBPos, Quaternion.identity);
                    }
                    else
                        measurePinAPos = measurePinBPos = Vector3.zero;
                }
            }
        }
    }
}
