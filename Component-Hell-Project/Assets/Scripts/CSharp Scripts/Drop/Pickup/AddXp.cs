using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AddXp : MonoBehaviour
{
    [SerializeField] private float xpToAdd = 1f;
    private IObjectPool<AddXp> xpPool;

    [SerializeField] private InvisibilityChecker invisibilityChecker;

    public void Add()
    {
        XpManager.Instance.AddXP(xpToAdd);
    }

    private void OnEnable()
    {
        invisibilityChecker.OnInvisibleTooLong.AddListener(ReleaseFromPool);
    }

    private void OnDisable()
    {
        invisibilityChecker.OnInvisibleTooLong.RemoveListener(ReleaseFromPool);
    }

    public void SetPool(IObjectPool<AddXp> xpPool)
    {
        this.xpPool = xpPool;
    }
    
    public void ReleaseFromPool()
    {
        xpPool.Release(this);
    }
}