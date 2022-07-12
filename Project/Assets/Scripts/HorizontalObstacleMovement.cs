using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
    [SerializeField] float obstacleSpeed = 2f;
    [SerializeField] float horizontalWidht = 5f;
   
    void Update()
    {
       transform.localPosition = new Vector3(SineAmount(), transform.localPosition.y,transform.localPosition.z);
    }

    public float SineAmount() => Mathf.Sin(Time.time * obstacleSpeed) * horizontalWidht;

}
