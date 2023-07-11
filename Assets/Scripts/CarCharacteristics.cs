using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCharacteristics : MonoBehaviour {

    [SerializeField] private float speedCurrentKmPerHour;
    public float moveDurationTimeSec = 2f;
    public float targetSpeed;
    public float currentSpeedMPerSec = 0f;
    public float maxSpeedMPerSec = 100f;
    public float accelerationMPerSec = 11.1f;
    public float maxDistance;
    public float minDistance = 0f;
    public float steeringAngel = 100f;
    
    private void Start () { 
        maxDistance = accelerationMPerSec * moveDurationTimeSec;
        targetSpeed = maxDistance / moveDurationTimeSec;
    }
    private void Update () {
        speedCurrentKmPerHour = currentSpeedMPerSec * 3.6f;
    }
}
