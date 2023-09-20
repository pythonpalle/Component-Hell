using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponHandler : MonoBehaviour, IMovementListener
{
    [Header("Weapons Owned")]
    [SerializeField] private List<Weapon> weapons;
    
    [Header("Data Container")] 
    [SerializeField] private WeaponDataContainer _weaponDataContainer;
    
    [Header("Events")]
    public UnityEvent<WeaponDataHolder> OnUpdateData;
    public UnityEvent<Weapon> OnWeaponAdded;
    
    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
    }

    private void Start()
    {
        foreach (var weaponInstance in weapons)
        {
            HandleInitialDataUpdate(weaponInstance);
        }
        
        GameUpgradeManager.Instance.OnUpgrade.AddListener(OnUpgrade);
    }

    private void OnDestroy()
    {
        GameUpgradeManager.Instance.OnUpgrade.RemoveListener(OnUpgrade);
    }

    private void Update()
    {
        TryAttackWithWeapons();
    }

    void TryAttackWithWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.TryAttack();
        }
    }

    public Weapon AddWeapon(Weapon weaponPrefab)
    {
        var weaponInstance = Instantiate(weaponPrefab, transform);
        weapons.Add(weaponInstance);
        OnWeaponAdded?.Invoke(weaponInstance);

        HandleInitialDataUpdate(weaponInstance);
        return weaponInstance;
    }

    public void OnUpgrade(UpgradeManager manager)
    {
        if (manager.ManagerType == UpgradeMangerType.WeaponHolder)
        {
            foreach (var weapon in weapons)
            {
                TransferData(weapon);
            }
        }
    }

    private void HandleInitialDataUpdate(Weapon weaponInstance)
    {
        TransferData(weaponInstance);
        OnUpdateData.AddListener(weaponInstance.WeaponDataContainer.UpdateData);
    }

    void TransferData(Weapon weapon)
    {
        WeaponDataContainer.TransferData(_weaponDataContainer.WeaponData, weapon.WeaponDataContainer.WeaponData);
    }

    public void OnMovementChange(Vector2 direction)
    {
        foreach (var weapon in weapons)
        {
            weapon.UpdateDirection(direction);
        }
    }
}
