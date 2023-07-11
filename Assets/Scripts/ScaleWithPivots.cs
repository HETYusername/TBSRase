using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleWithPivots : MonoBehaviour {

    [SerializeField] private GameObject startObj;
    [SerializeField] private GameObject endObj;
    [SerializeField] private VisionCone cone;
    private Vector3 initialScale;
    private Vector3 midlePoint;
    private Vector3 rotationDirection;
    private float distance;


    private void Start(){
        initialScale = transform.localScale;
        UpdateTransformForScale();
    }

    
    private void Update(){
        if (startObj.transform.hasChanged || endObj.transform.hasChanged)
        {
            UpdateTransformForScale();
        }        
    }


    private void UpdateTransformForScale(){
        cone.visionRange = Vector3.Distance(startObj.transform.position, endObj.transform.position);
    }
}
