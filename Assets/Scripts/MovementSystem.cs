using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject target;
    [SerializeField] private CarCharacteristics carCharacteristics;
    [SerializeField] private Canvas canvas;

    public Vector3 carDirection;
    public Vector3 newCarPosition;
    private bool isMoving = false;
    private SpriteRenderer targetRender;
    private GameObject visionCone;
    private Quaternion targetRotation;



    private void Awake() {
        carDirection = target.transform.position - car.transform.position;
        targetRender = target.GetComponentInChildren<SpriteRenderer>();
        visionCone = car.transform.Find("VisionCone").gameObject;
    }

    public void MakeMove() {
        ChangeCarPosition();
        ChangeTargetPosition();
        SetCarCharacteristics();
    }

    private void ChangeCarPosition() {
        carDirection = target.transform.position - car.transform.position;
        targetRotation = Quaternion.LookRotation(carDirection);
        car.transform.rotation = targetRotation;
        newCarPosition = target.transform.position;
        carCharacteristics.currentSpeedMPerSec = Vector3.Distance(car.transform.position, newCarPosition) / carCharacteristics.moveDurationTimeSec;
        
        isMoving = true;
    }

    private void ChangeTargetPosition() {
        target.transform.position = newCarPosition + carDirection.normalized * carCharacteristics.currentSpeedMPerSec * carCharacteristics.moveDurationTimeSec;
    }

    private void SetCarCharacteristics() {
        carCharacteristics.minDistance = carCharacteristics.currentSpeedMPerSec * carCharacteristics.moveDurationTimeSec - carCharacteristics.accelerationMPerSec * carCharacteristics.moveDurationTimeSec;
        carCharacteristics.maxDistance = carCharacteristics.currentSpeedMPerSec * carCharacteristics.moveDurationTimeSec + carCharacteristics.accelerationMPerSec * carCharacteristics.moveDurationTimeSec;
        if (carCharacteristics.minDistance < 0f) {
            carCharacteristics.minDistance = 0f;
        }
        if (carCharacteristics.maxDistance > 200f) {
            carCharacteristics.maxDistance = 200f;
        }
    }

    private void Update() {
        if (isMoving) {
            targetRender.enabled = false;
            canvas.enabled = false;
            visionCone.SetActive(false);

            car.transform.position = Vector3.MoveTowards(car.transform.position, newCarPosition, carCharacteristics.currentSpeedMPerSec * Time.deltaTime);
        }

        if (car.transform.position == newCarPosition) {
            isMoving = false;
            targetRender.enabled = true;
            canvas.enabled = true;
            visionCone.SetActive(true);
        }
    }
}
