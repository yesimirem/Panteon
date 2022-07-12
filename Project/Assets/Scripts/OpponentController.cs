using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] List<float> waypointsZ;

    private Vector3 destination;
    private Animator animator;
    private int currentWaypoint = 0;
    public bool isFinished = false;

    void Start()
    {
        agent.updateRotation = false;
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
        destination = new Vector3(Random.Range(-9f, 9f), transform.position.y, 245);
        agent.SetDestination(destination);
    }

    void Update()
    {
        if (!isFinished)
        {
            CheckCurrentWaypoint();
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
    }

    private void CheckCurrentWaypoint()
    {
        if (transform.position.z >= waypointsZ[currentWaypoint])
        {
            currentWaypoint++;
            if (currentWaypoint == waypointsZ.Count)
            {
                animator.SetBool("isRunning", false);
                isFinished = true;
            }
        }
    }

    public int GetCurrentWaypoint()
    {
        return currentWaypoint;
    }

    public void ResetTheProgress()
    {
        currentWaypoint = 0;
    }
}
