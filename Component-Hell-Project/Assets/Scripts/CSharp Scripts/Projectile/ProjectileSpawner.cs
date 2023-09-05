using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileDefinition))]
public class ProjectileSpawner : MonoBehaviour
{
    private ProjectileDefinition _projectileDefinition;

    private void OnEnable()
    {
        _projectileDefinition = GetComponent<ProjectileDefinition>();
    }

    public void SpawnProjectile()
    {
        Instantiate(_projectileDefinition);
    }
}
