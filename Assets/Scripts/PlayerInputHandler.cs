using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake() {
        // Enable enhanced touch support if not already
        if (!EnhancedTouchSupport.enabled)
            EnhancedTouchSupport.Enable();
    }

    public void Pinch(InputAction.CallbackContext context) {

        // if there are not two active touches, return
        if (Touch.activeTouches.Count < 2)
            return;

        // get the finger inputs
        Touch primary = Touch.activeTouches[0];
        Touch secondary = Touch.activeTouches[1];

        // check if none of the fingers moved, return
        if (primary.phase == TouchPhase.Moved || secondary.phase == TouchPhase.Moved) {
            // if fingers have no history, then return
            if (primary.history.Count < 1 || secondary.history.Count < 1)
                return;

            // calculate distance before and after touch movement
            float currentDistance = Vector2.Distance(primary.screenPosition, secondary.screenPosition);
            float previousDistance = Vector2.Distance(primary.history[0].screenPosition, secondary.history[0].screenPosition);

            // the zoom distance is the difference between the previous distance and the current distance
            float pinchDistance = currentDistance - previousDistance;
            Zoom(pinchDistance);
        }
    }

    public void Scroll(InputAction.CallbackContext context) {

        if (context.phase != InputActionPhase.Performed)
            return;

        float scrollDistance = context.ReadValue<Vector2>().y;
        Zoom(scrollDistance);
    }

    public void Zoom(float distance) {
        distance = distance * 0.01f;
        cinemachineVirtualCamera.m_Lens.FieldOfView -= distance;

    }

}
