using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberDisplayer : MonoBehaviour
{
    [SerializeField] private TextObject textObjectPrefab;
    
    public void DisplayDamageNumber(float damage)
    {
        var textObj = Instantiate(textObjectPrefab, transform.position, quaternion.identity);
        textObj.SetText(damage.ToString(CultureInfo.InvariantCulture));
    }
}