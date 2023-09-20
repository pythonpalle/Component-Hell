using UnityEngine;

public class ChildToProjectile : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    
    void OnEnable()
    {
        int oldMask = layerMask;
        layerMask = 0;
        var toChildObject = Physics2D.OverlapCircle(transform.position, 2f, LayerMask.NameToLayer("Player Proejctile"));
        layerMask = oldMask;
        
        Debug.Log("To Child Object: " + toChildObject.name);
        transform.parent = toChildObject.transform;
    }
}