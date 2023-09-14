using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    [SerializeField] protected MetaContainer _metaContainer;
    public MetaContainer MetaContainer => _metaContainer;
    [SerializeField] private bool findMetaContainer = true;

    public virtual void Setup(MetaContainer container)
    {
        _metaContainer = container;
    }

    protected virtual void Awake()
    {
        if (findMetaContainer && !_metaContainer)
            TryAttachToMetaContainer(transform);
    }
    
    private bool TryAttachToMetaContainer(Transform transformToCheck)
    {
        _metaContainer = transformToCheck.GetComponentInChildren<MetaContainer>();
        if (_metaContainer)
        {
            return true;
        }

        var parentTransform = transformToCheck.parent;
        if (parentTransform == null)
        {
            _metaContainer = null;
            return false;
        }

        return TryAttachToMetaContainer(parentTransform);
    }
}
