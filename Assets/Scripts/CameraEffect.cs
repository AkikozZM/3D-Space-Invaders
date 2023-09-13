using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration;
    public float shakeIntensity; 

    private Vector3 originalPosition;
    private float shakeTimer = 0f;

    void Start()
    {
        originalPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset camera
            shakeTimer = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void StartShake()
    {
        shakeTimer = shakeDuration;
    }
}
