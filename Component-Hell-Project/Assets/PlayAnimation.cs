using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParameterType
{
    Trigger,
    Boolean,
}

public class PlayAnimation : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    
    [Header("Parameter")]
    [SerializeField] private string parameterString;
    
    // TODO: Gör parameter till scriptable object eller liknande
    [SerializeField] private ParameterType parameterType;
    [SerializeField] private bool check;

    public void Play()
    {
        // Check if the animator and clip are assigned
        if (animator != null)
        {
            switch (parameterType)
            {
                case ParameterType.Trigger:
                    animator.SetTrigger(parameterString);
                    break;
                case ParameterType.Boolean:
                    animator.SetBool(parameterString, check);
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Animator not assigned.");
        }
    }
}
