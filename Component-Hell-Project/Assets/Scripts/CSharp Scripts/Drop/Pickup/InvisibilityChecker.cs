using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InvisibilityChecker : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    public UnityEvent OnInvisibleTooLong;

    
    private float timeOfLastInvisible;
    private bool visible = true;
    Camera mainCamera;


    private void OnEnable()
    {
        timeOfLastInvisible = Time.time;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateVisibilityCheck();
        
        if (!visible && Time.time > timeOfLastInvisible + lifeTime)
        {
            OnInvisibleTooLong?.Invoke();
        }
    }

    private void UpdateVisibilityCheck()
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(gameObject.transform.position);

        if (!visible && viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0)
        {
            visible = true;
            timeOfLastInvisible = Time.time;
        }
        else
        {
            visible = false;
        }
    }
}