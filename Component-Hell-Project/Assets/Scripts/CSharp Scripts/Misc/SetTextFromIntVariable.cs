using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextFromIntVariable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private IntVariable intVariable;

    public void SetText()
    {
        textMesh.text = intVariable.value.ToString();
    }
}
