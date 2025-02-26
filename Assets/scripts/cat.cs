using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{
    public GameObject player;
    public bool hasBeenPet = false;
    public List<Material> sprites;
    [SerializeField]
    private MeshRenderer sprite;
    public Collider DetectionRadius;
    public bool sleeping = false;
    public AudioClip alert;

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
        LookTowards2D();
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
        GetComponent<AudioSource>().PlayOneShot(alert);
        Debug.Log("Detected by cat");
    }
}
