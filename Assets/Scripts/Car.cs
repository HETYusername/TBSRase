using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Exit");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("Stay");
        Debug.Log(collision.name);
    }
}
