using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddXp : MonoBehaviour
{
    [SerializeField] private float xpToAdd = 1f;

    public void Add()
    {
        XpManager.Instance.AddXP(xpToAdd);
    } 
}
