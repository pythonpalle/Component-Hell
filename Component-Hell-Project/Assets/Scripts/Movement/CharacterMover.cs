using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
