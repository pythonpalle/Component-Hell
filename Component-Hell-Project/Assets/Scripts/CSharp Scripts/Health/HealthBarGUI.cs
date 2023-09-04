using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarGUI : MonoBehaviour
{
    [SerializeField] private FloatVariable playerCurrentHealth;
    [SerializeField] private FloatVariable playerMaxHealth;
    [SerializeField] private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerCurrentHealth.value / playerMaxHealth.value;
    }
}
