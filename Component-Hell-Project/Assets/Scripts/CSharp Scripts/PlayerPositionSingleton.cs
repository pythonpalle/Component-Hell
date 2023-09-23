using UnityEngine;

public class PlayerPositionSingleton : MonoBehaviour
{
    public static PlayerPositionSingleton Instance { get; private set; }
    public Vector2 Position { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Position = transform.position;
    }
}