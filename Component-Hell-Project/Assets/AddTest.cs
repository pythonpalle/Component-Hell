using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTest : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    [SerializeField] private ComponentAdder adder;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddUpgrade();
        }
    }

    private void AddUpgrade()
    {
        _weapon.GetComponent<AddComponentsToMonoBehaviour>().AddNewComponent(adder);
    }
}
