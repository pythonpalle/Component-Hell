using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Types/PrefabAdd")]
public class PrefabAddUpgrade : UpgradeObject
{
    [SerializeField] private MonoBehaviour prefabToAdd;
    public override void Apply(Transform owner)
    {
        var addGameObjectClass = owner.GetComponent<AddGameObjectsToMonoBehaviour>();
        addGameObjectClass.AddPrefab(prefabToAdd); 
    }
}