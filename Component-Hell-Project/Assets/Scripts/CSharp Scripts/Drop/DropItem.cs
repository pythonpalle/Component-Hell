using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject itemToDrop;
    
    public void Drop()
    {
        Instantiate(itemToDrop);
    }
}
