using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Camera cam;
    public float range = 50f;
    public new ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the mouse button is clicked then fire
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Gun fire animation
        var animation = GetComponent<Animation>();
        animation.Play("Shoot");
        // Gun fire sound
        var sound = GetComponent<AudioSource>();
        sound.Play();
        // Play Particle
        particleSystem.Play();
        // Collision
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // Gets the enemy and apply dammage if there is one
            var e = hit.transform.GetComponent<EnemyHandler>();
            if (e != null)
                e.Damage();
        }
    }
}
