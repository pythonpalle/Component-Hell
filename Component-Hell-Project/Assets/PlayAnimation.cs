using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip clip;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        // Check if the animator and clip are assigned
        if (animator != null && clip != null)
        {
            // Get the name of the clip and play it
            string clipName = clip.name;
            animator.Play(clipName);
            Debug.Log("Play anim");
        }
        else
        {
            Debug.LogWarning("Animator or AnimationClip not assigned.");
        }
    }
}
