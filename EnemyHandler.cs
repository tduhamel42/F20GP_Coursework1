using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public float speed = 4;
    public float range = 20;
    public float stopDistance = 2;
    public GameObject player;
    public int health = 30;
    private bool dead = false;

    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            playerTransform = player.transform;
    }
    public void SetTarget(GameObject obj)
    {
        player = obj;
        playerTransform = player.transform;
    }

    public void Damage()
    {
        var animator = gameObject.GetComponent<Animator>();
        if (health > 0)
        {
            animator.Play("GetHit");
            health -= 10;
        }
        // Death condition
        else
        {
            animator.Play("Die");
            dead = true;
            // Wait for the animation to play before destroying the object
            Destroy(gameObject, 3f);
        }
    }
    bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    bool AnimatorIsPlaying(Animator animator, string stateName)
    {
        return AnimatorIsPlaying(animator) && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is set and the enemy is not dead
        if (player != null && !dead)
        {
            // Looks at the player
            transform.LookAt(playerTransform);
            var animator = gameObject.GetComponent<Animator>();
            var distance = Vector3.Distance(playerTransform.position, transform.position);
            // If the player is in range
            if (distance <= range)
            {
                // If the player is not close enough the enemy moves toward the player
                if (distance >= stopDistance)
                {
                    transform.position += transform.forward * speed * Time.deltaTime;
                    // Check if the GetHit animation is done playing (so it doesn't look weird)
                    if (!AnimatorIsPlaying(animator, "GetHit"))
                        animator.Play("WalkForwardBattle");
                }
                else
                {
                    animator.Play("Attack01");
                    // Randomise the attacks against the player
                    if (Random.Range(0, 150) >= 140)
                    {
                        // Apply the damage to the player
                        player.GetComponent<PlayerHandler>().Damage();
                        GetComponent<AudioSource>().Play();
                    }
                }
            }
            else
            {
                animator.Play("Idle_Battle");
            }
        }
    }
}
