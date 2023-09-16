using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class DamageNumberDisplayer : MonoBehaviour
{
    [SerializeField] private TextObject textObjectPrefab;
    
    public void DisplayDamageNumber(float damage)
    {
        var textObj = Instantiate(textObjectPrefab, transform);
        textObj.SetText(damage.ToString(CultureInfo.InvariantCulture));
    }
}