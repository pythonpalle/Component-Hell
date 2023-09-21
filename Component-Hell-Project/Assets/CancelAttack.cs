using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelAttack : MonoBehaviour
{
    private WeaponHandler handler;
    
    // Start is called before the first frame update
    void Start()
    {
        handler = GetComponent<WeaponHandler>(); 
    }

    public void Cancel()
    {
        handler.CancelAttacks();
    }
}
