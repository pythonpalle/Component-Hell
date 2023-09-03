using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : MonoBehaviour
{
    protected CharacterMover characterMover;
    void Awake()
    {
        characterMover = GetComponent<CharacterMover>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!characterMover)
            return;
    }
}
