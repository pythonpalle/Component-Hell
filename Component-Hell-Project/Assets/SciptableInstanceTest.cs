using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class SciptableInstanceTest : MonoBehaviour
{
    [SerializeField] private Object prefab;
    [SerializeField] private Object instance;


    private void OnEnable()
    {
        instance = Object.Instantiate(prefab);
    }
}
