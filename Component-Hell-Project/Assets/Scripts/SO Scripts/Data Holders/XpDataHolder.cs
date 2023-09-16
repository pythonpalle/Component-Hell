using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/XpData")]
public class XpDataHolder : ScriptableObject
{
    public float totalXP;
    public float levelXP;
    public float xpNeededForNextLevel;
}
