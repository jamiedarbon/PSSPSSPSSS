using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookTowards(GameObject Target)
    {
        Vector3 direction = Target.transform.position - transform.position;
        direction = new Vector3(direction.x, -90, direction.z);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
