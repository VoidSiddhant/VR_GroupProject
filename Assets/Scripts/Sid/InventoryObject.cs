using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObject : MonoBehaviour
{
    public GameObject inventoryObjectPrefab;
    public Sprite thumbnail;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = thumbnail;
        GetComponentInChildren<TextMeshProUGUI>().text = inventoryObjectPrefab.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 5.0f;
        randomPoint += Player.Instance.transform.position;
        randomPoint.y = Player.Instance.transform.position.y;
        GameObject go = Instantiate(inventoryObjectPrefab, randomPoint, Quaternion.identity);

    }
}
