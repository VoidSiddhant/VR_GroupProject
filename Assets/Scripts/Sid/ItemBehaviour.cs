using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnKeyboard()
    {
        canvas.gameObject.SetActive(true);
        GameManager.Instance.ToggleKeyboard(true);
        //GameManager.Instance.keyboard.
    }

    public void TurnOffKeyboard()
    {
       // canvas.gameObject.SetActive(true);
        GameManager.Instance.ToggleKeyboard(false);
    }

    public void ToggleKeyboard()
    {
        if (GameManager.Instance.keyboard.gameObject.activeSelf)
            this.TurnOffKeyboard();
        else
            this.TurnOnKeyboard();
    }

    public void TurnOnAnnotation()
    {
        canvas.gameObject.SetActive(true);

    }

    public void TurnOffAnnotation()
    {
        canvas.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(textObject.text.Length > 0)
                TurnOnAnnotation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TurnOffAnnotation();
        }
    }

}
