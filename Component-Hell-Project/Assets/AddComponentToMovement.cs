using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentToMovement : MonoBehaviour
{
    [SerializeField] private List<Object> components;
    
    public void AddComponentToGO(MonoBehaviour mb)
    {
        foreach (var component in components)
        {
            AddComponentToMonoBehaviour(mb, component);
        }
    }

    private void AddComponentToMonoBehaviour(MonoBehaviour mb, Object component)
    {
        string scriptTypeName = component.name;
        
        if (!string.IsNullOrEmpty(scriptTypeName))
        {
            GameObject toAddObject = mb.gameObject;
    
            // Use reflection to get the script type by name
            System.Type scriptType = System.Type.GetType(scriptTypeName);
    
            if (scriptType != null)
            {
                // Check if the scriptType is a MonoBehaviour
                if (typeof(MonoBehaviour).IsAssignableFrom(scriptType))
                {
                    // Add the component
                    toAddObject.AddComponent(scriptType);
                }
                else
                {
                    Debug.LogWarning("The selected type is not a MonoBehaviour.");
                }
            }
            else
            {
                Debug.LogWarning("Failed to find the script type with the provided name: " + scriptTypeName);
            }
        }
        else
        {
            Debug.LogWarning("No script type name provided.");
        }
    }
}
