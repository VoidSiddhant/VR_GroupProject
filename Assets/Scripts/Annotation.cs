using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;
using UnityEditor;

public class Annotation : MonoBehaviour
{
    private string text;

    public void Save(string updateStr)
    {
        text = updateStr;
    }

    public string Load()
    {
        return text;
    }
}
