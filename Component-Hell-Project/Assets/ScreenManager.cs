using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;
    private Vector2 ScreenBounds { get; set; }
    private Camera screenCamera;

    public float minX { get; private set; }
    public float minY { get; private set; }
    public float maxX { get; private set; }
    public float maxY { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
        screenCamera = Camera.main;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(screenCamera.transform.position, screenCamera.transform.position + (Vector3) ScreenBounds);
        Gizmos.DrawLine(screenCamera.transform.position, screenCamera.transform.position - (Vector3) ScreenBounds);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScreenBounds();
    }

    private void UpdateScreenBounds()
    {
        var cameraHeight = screenCamera.orthographicSize;
       var  cameraWidth = cameraHeight * screenCamera.aspect;
       
       ScreenBounds = new Vector2(cameraWidth, cameraHeight);

       var cameraPos = screenCamera.transform.position;

       maxX = cameraPos.x + cameraWidth;
       minX = cameraPos.x - cameraWidth;
       
       maxY = cameraPos.y + cameraHeight;
       minY = cameraPos.y - cameraHeight;
    }
}
