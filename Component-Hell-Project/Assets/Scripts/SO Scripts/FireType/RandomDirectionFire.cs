using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(menuName = "ScriptableObjects/FireTypes/RandomDirection")]
public class RandomDirectionFire : FireType
{
    [SerializeField] private bool randomiseEachRound;
    private Vector2 direction;
    private System.Random _random = new Random();

    protected override Vector2 GetPosition(Weapon owner, int round)
    {
        return owner.transform.position;
    }

    protected override Vector2 GetDirection(Weapon owner, int round)
    {
        if (randomiseEachRound || round == 0)
        {
            direction = new Vector2
            {
                x = (float) _random.NextDouble()*2 -1,
                y = (float) _random.NextDouble()*2 -1
            };
        }

        return direction;
    }
}
