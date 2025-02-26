using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{
    public GameObject player;
    public bool hasBeenPet = false;
    public bool fleeing = false;
    public List<Material> sprites;
    [SerializeField]
    private MeshRenderer sprite;
    private int runTimer = 0;
    public Collider DetectionRadius;
    public bool sleeping = false;
    public AudioClip alert;
    private float maxSpeed = 10f;

    private void Start()
    {
        // Apply relevant logic for the sleeping cat type
        if(sleeping)
        {
            GetComponent<Animator>().SetBool("Sleeping", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Keep speed within limit
        if (GetComponentInParent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponentInParent<Rigidbody>().velocity = GetComponentInParent<Rigidbody>().velocity.normalized * maxSpeed;
        }
        LookTowards2D();
        if(fleeing)
        {
            flee();
        }
    }

    // Custom LookTowards function as I currently cannot be asked to figure out why the cat's orientation is wrong
    void LookTowards2D()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = new Vector3(direction.x, -90, direction.z);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    // Logic for the sleeping cat type
    public void sleepingCat()
    {
        GetComponent<Animator>().SetBool("Sleeping", false);
        GetComponent<MeshRenderer>().material = sprites[1];
        GetComponentInParent<AudioSource>().PlayOneShot(alert);
        Debug.Log("Detected by cat");
    }

    // Fleeing functionality
    public void flee()
    {
        // Move the cat backwards for 2 seconds (60 fps)
        if(runTimer < 120)
        {
            Debug.Log("Fleeing");
            Vector3 fleeDirection = player.transform.position - transform.position;
            GetComponentInParent<Rigidbody>().AddForce(-fleeDirection * speed * 10 * Time.deltaTime);
            runTimer++;
        } 
        // Stop the movement after 2 seconds.
        else if (runTimer >= 120)
        {
            GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
            runTimer = 0;
            fleeing = false;
        }
    }
}
