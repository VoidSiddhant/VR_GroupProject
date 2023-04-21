using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class MeasureToolManager : MonoBehaviour
{
    public Transform raycastPoint;

    public bool enableMeasureTool = false;
    public LayerMask measureToolLayer;

    public GameObject measurePinA,measurePinB;
    public LineRenderer lineRenderer;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableMeasureTool)
        {
            if(measurePinA.activeSelf == true && measurePinB.activeSelf == true)
            {
                lineRenderer.SetPosition(0, measurePinA.transform.position);
                lineRenderer.SetPosition(1, measurePinB.transform.position);
                text.text = Vector3.Distance(measurePinA.transform.position, measurePinB.transform.position).ToString();
            }
            RaycastHit hitInfo;
            Ray ray = new Ray(raycastPoint.transform.position, raycastPoint.transform.forward * -1.0f);
            Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red);
            if (Physics.Raycast(ray, out hitInfo, 10.0f, measureToolLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.green);

                if (Input.GetMouseButtonDown(0))
                {
                    if (measurePinA.activeSelf == false)
                    {
                        measurePinA.SetActive(true);
                        measurePinA.transform.position = hitInfo.point;
                        
                    }
                    else if (measurePinB.activeSelf == false)
                    {
                        measurePinB.SetActive(true);
                        measurePinB.transform.position = hitInfo.point;
                        lineRenderer.enabled = true;
                    }
                    else
                    {
                        lineRenderer.enabled = false;
                        measurePinA.SetActive(false);
                        measurePinB.SetActive(false);
                    }
                }
            }
        }
    }
}
