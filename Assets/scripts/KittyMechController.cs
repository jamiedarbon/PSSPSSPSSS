using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyMechController : Enemy
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookTowards(Player);
    }
}
