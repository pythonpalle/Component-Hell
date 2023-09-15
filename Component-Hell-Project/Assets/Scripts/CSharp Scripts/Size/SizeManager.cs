using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour, IProjectileSpawnListener
{
   [SerializeField] private Transform sizeTransform;
   [SerializeField] private DynamicFloat size;
   
   public void OnProjectileSpawn(WeaponDataHolder data, Vector2 _)
   {
       var multSize = data.attackSize;
       size.AddMultiplier(data.name, multSize.Value);
   }
}

public interface IProjectileSpawnListener
{
    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 direction);
}
