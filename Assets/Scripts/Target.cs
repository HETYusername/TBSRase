using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Target : MonoBehaviour {

    [SerializeField] private GameObject car;
    [SerializeField] private MovementSystem movementSystem;
    [SerializeField] private float distance;
    [SerializeField] private CarCharacteristics carCharacteristics;

    private Camera mainCamera;
    private Vector3 mousePosition;
    private Ray ray;
    private float angle;
    private Vector3 directionToMove;
    private Quaternion targetRotation;


    void Start() {
        mainCamera = Camera.main;
    }


    private void OnMouseUp() {
        transform.hasChanged = false;
    }

    void OnMouseDrag() {
        // Get ray which starts from the main cinemachineVirtualCamera and goes through the mouse position
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo)) {
            mousePosition = hitInfo.point;
        }
        mousePosition.y = 0;
        directionToMove = mousePosition - car.transform.position;

        angle = Vector3.SignedAngle(directionToMove, movementSystem.carDirection, movementSystem.carDirection);


        distance = Vector3.Distance(car.transform.position, mousePosition);
        distance = Mathf.Clamp(distance, carCharacteristics.minDistance, carCharacteristics.maxDistance);

        if (Mathf.Abs(angle) <= carCharacteristics.steeringAngel * (1 - carCharacteristics.currentSpeedMPerSec / carCharacteristics.maxSpeedMPerSec)) {

            // Rotate target to the move direction
            targetRotation = Quaternion.LookRotation(directionToMove);
            transform.rotation = targetRotation;

            Vector3 restrictedPosition = car.transform.position + directionToMove.normalized * distance;
            transform.position = restrictedPosition;
        }
        else {
            directionToMove = this.transform.position - car.transform.position;

            Vector3 restrictedPosition = car.transform.position + directionToMove.normalized * distance;

            transform.position = restrictedPosition;
        }
    }

}
