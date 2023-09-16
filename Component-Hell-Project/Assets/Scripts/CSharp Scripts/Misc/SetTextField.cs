using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void SetText(string text)
    {
        textMesh.text = text;
    }

    public void SetText(int number)
    {
        textMesh.text = number.ToString();
    }
}
