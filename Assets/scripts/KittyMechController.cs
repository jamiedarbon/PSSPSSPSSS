using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyMechController : Enemy
{
    private GameObject Player;
    private GameObject LeftPaw, RightPaw;

    private Animator animator;
    private AnimatorClipInfo[] animatorinfo;
    private string current_animation;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        LeftPaw = GameObject.Find("Bone.011");
        RightPaw = GameObject.Find("Bone.003");

        animator = GetComponent<Animator>();

        LeftPaw.GetComponent<SphereCollider>().enabled = false;
        RightPaw.GetComponent<SphereCollider>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        animatorinfo = this.animator.GetCurrentAnimatorClipInfo(0);
        current_animation = animatorinfo[0].clip.name;
        Debug.Log("Current animation: " + current_animation);
        if (current_animation != "Armature.007_Pounce Attack")
        {
            if (current_animation != "Armature.007_Armature.007Action")
            {
                LookTowards(Player);
            }
        }
        //Debug.Log(LeftPaw + " " + RightPaw);
    }
}
