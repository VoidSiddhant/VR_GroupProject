using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public GameObject canvas;
    public float minDst = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dst = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(Player.Instance.transform.position.x, Player.Instance.transform.position.z));
        if (dst <= minDst && textObject.text.Length > 0)
        {
            canvas.gameObject.SetActive(true);
        }
        else if (dst > minDst && GameManager.Instance.keyboard.gameObject.activeSelf == false)
            canvas.gameObject.SetActive(false);
    }

    public void TurnOnKeyboard()
    {
        canvas.gameObject.SetActive(true);
        GameManager.Instance.ToggleKeyboard(true);
        GameManager.Instance.SetAnnotation(this);
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

    public void updateNote(string name)
    {
        textObject.text = name;
        string word = name.Split(' ')[0];

        GameManager.Instance.updateAnnotationButton(this, word);
    }
}
