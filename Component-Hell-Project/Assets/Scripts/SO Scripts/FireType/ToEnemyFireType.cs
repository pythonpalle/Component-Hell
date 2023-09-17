using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FireTypes/ToEnemy")]
public class ToEnemyFireType : FireType
{
    [SerializeField] private bool findClosestEachRound;
    private Vector2 direction;


    protected override Vector2 GetDirection(Weapon owner, int round)
    {
        if (findClosestEachRound || round == 0)
        {
            Vector2 thisPos = owner.transform.position;
            var enemy = EnemyManager.Instance.FindClosestEnemy(thisPos);

            if (enemy)
            {
                Vector2 enemyPos = EnemyManager.Instance.FindClosestEnemy(thisPos).transform.position;
                direction = enemyPos - thisPos;
            }
        }
        
        return direction;
    }
}

