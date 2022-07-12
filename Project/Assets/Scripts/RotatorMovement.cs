using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f;

    void Update()
    {
       transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
}
