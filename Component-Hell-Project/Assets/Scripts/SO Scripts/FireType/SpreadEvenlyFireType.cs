using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FireTypes/SpreadEvenly")]
public class SpreadEvenlyFireType : FireType
{
    [SerializeField] private bool startAtDiagonal = true;
    
    protected override Vector2 GetDirection(Weapon owner, int round, int shotInRound)
    {
        float degrees = (360f / shotsPerRound * shotInRound);//* Mathf.Deg2Rad;
        if (startAtDiagonal) degrees += 45;
        

        var direction = Quaternion.Euler(0, 0, degrees) * Vector2.up;
        return direction;
    }
}