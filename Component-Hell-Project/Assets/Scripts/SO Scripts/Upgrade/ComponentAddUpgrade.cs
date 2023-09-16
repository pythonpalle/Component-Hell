using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/ComponentAdd")]
public class ComponentAddUpgrade : UpgradeObject
{
    [SerializeField] private ComponentAdder _componentAdder;
    public override void Apply(Transform owner)
    {
        var addComponentClass = owner.GetComponent<AddComponentsToMonoBehaviour>();
        addComponentClass.AddNewComponent(_componentAdder); 
    }
}