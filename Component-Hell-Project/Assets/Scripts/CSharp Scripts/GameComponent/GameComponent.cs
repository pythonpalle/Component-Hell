using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    [SerializeField] protected MetaContainer _metaContainer;
    public MetaContainer MetaContainer => _metaContainer;

    public void SetMetaContainer(MetaContainer container)
    {
        _metaContainer = container;
    }
}
