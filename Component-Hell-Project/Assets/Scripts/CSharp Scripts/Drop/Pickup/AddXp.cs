using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AddXp : MonoBehaviour
{
    [SerializeField] private float xpToAdd = 1f;
    [SerializeField] private float lifeTime = 10f;
    public float timeOfLastInvisible;
    private IObjectPool<AddXp> xpPool;

    public bool visible = true;

    Camera mainCamera;

    public void Add()
    {
        XpManager.Instance.AddXP(xpToAdd);
    }

    private void OnEnable()
    {
        timeOfLastInvisible = Time.time;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateVisibilityCheck();
        
        

        if (!visible && Time.time > timeOfLastInvisible + lifeTime)
        {
            ReleaseFromPool();
        }
    }

    private void UpdateVisibilityCheck()
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(gameObject.transform.position);

        if (!visible && viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0)
        {
            visible = true;
            timeOfLastInvisible = Time.time;
        }
        else
        {
            visible = false;
        }
    }

    // private void OnBecameVisible()
    // {
    //     visible = true;
    // }
    //
    // private void OnBecameInvisible()
    // {
    //     Debug.Log("Invisible");
    //     
    //     visible = false;
    //     timeOfLastInvisible = Time.time;
    // }

    public void SetPool(IObjectPool<AddXp> xpPool)
    {
        this.xpPool = xpPool;
    }
    
    public void ReleaseFromPool()
    {
        xpPool.Release(this);
    }
}
