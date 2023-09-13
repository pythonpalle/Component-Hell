using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : Container
{
    [SerializeField] private FloatValueWrapper maxHealthWrapper;
    public FloatValueWrapper MaxHealthWrapper => maxHealthWrapper;

    [SerializeField] private CharacterHealth _characterHealth;
    public CharacterHealth CharacterCharacterHealth => _characterHealth;
}
