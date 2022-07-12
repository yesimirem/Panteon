using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Vector3 centerPoint;
    private Vector3 newPos;
    private bool startTouch = false;
    [SerializeField] float radius = 1.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        InputsControl();
        RotateAndMove();
    }

    private void InputsControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = true;
            centerPoint = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }

        if (Input.GetMouseButton(0))
        {
            newPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }
        else
        {
            startTouch = false;
        }
    }

    private void RotateAndMove()
    {
        if (startTouch)
        {
            Vector3 offset = newPos - centerPoint;
            if(offset != Vector3.zero)
            {
                animator.SetBool("isRunning", true);
            }

            Vector3 direction = Vector3.ClampMagnitude(offset, radius);
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

}
