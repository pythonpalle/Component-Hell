using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.Serialization;
using System.Runtime.Serialization;


public class AddComponentToGameObject : MonoBehaviour
{
    [SerializeField] private Object componentType;

    public void AddComponentToGO(Projectile p)
    {
        string scriptTypeName = componentType.name;
        Debug.Log("Name: " + scriptTypeName);
        
        if (!string.IsNullOrEmpty(scriptTypeName))
        {
            GameObject toAddObject = p.gameObject;
    
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
