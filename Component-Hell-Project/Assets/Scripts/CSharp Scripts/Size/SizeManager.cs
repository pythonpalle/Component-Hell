using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour, IWeaponDataUpdateListener
{
   [SerializeField] private Transform sizeTransform;
   [SerializeField] private DynamicFloat size;
   
   public void OnWeaponDataUpdate(WeaponDataHolder data)
   {
       var multSize = data.attackSize;
       size.AddMultiplier(data.name, multSize.Value);

       sizeTransform.localScale = Vector3.one * size.Value;
   }
}

public interface IWeaponDataUpdateListener
{
    public void OnWeaponDataUpdate(WeaponDataHolder data);
}