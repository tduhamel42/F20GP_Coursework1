using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxHandler : MonoBehaviour
{

    public GameObject player;
    private float stopDistanceToPlayer = 15;
    private GameObject target;

    private Transform playerTransform;

    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            playerTransform = player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        animator.Play("Fox_Sit1");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            var distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
            if (distanceToPlayer >= stopDistanceToPlayer)
            {
                transform.LookAt(playerTransform);
                animator.Play("Fox_Sit1");
                agent.isStopped = true;
            }
            else
            {
                if (target != null)
                    agent.SetDestination(target.transform.position);
                agent.isStopped = false;
                animator.Play("Fox_Run");
            }
        }
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }
}
