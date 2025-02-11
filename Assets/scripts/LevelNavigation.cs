using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelNavigation : MonoBehaviour
{
    private int countdown = 50;
    private int level = 1;
    [SerializeField]
    public int[] scores;

    public GameObject Level;
    public GameObject LevelTime;
    private GameObject StateManager;
    public int tempScore;
    
    // Start is called before the first frame update
    void Start()
    {
        scores[0] = tempScore;
        scores[1] = 69;
        scores[2] = 143;
        Level = GameObject.Find("GeneralUI").transform.GetChild(0).transform.GetChild(1).gameObject;
        LevelTime = GameObject.Find("GeneralUI").transform.GetChild(0).transform.GetChild(3).gameObject;
        StateManager = GameObject.Find("StateManager");
        Level.gameObject.GetComponent<TextMeshProUGUI>().SetText((level + 1).ToString());
        LevelTime.gameObject.GetComponent<TextMeshProUGUI>().SetText(TimeSpan.FromSeconds(scores[0]).Minutes + " : " + TimeSpan.FromSeconds(scores[0]).Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        countdown--;
        Level.gameObject.GetComponent<TextMeshProUGUI>().SetText(((GetComponent<Animator>().GetInteger("Level")) + 1).ToString());

        //Keep level index within upper and lower bounds
        if (level > 3)
        {
            Debug.Log("Overflow");
            level = 1;
            StateManager.GetComponent<LevelStart>().level = 1;
            GetComponent<Animator>().SetInteger("Level", 0);
        }
        else if (level < 1)
        {
            Debug.Log("Underflow");
            level = 3;
            StateManager.GetComponent<LevelStart>().level = 3;
            GetComponent<Animator>().SetInteger("Level", 2);
        }

        //Handle level selection
        if (((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))) && countdown < 0)
        {
            level++;
            StateManager.GetComponent<LevelStart>().level++;
            GetComponent<Animator>().SetBool("Left", true);
            GetComponent<Animator>().SetInteger("Level", (GetComponent<Animator>().GetInteger("Level")) + 1);
            countdown = 50;
        }
        if(((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) && countdown < 0)
        {
            level--;
            StateManager.GetComponent<LevelStart>().level--;
            GetComponent<Animator>().SetBool("Right", true);
            GetComponent<Animator>().SetInteger("Level", (GetComponent<Animator>().GetInteger("Level")) - 1);
            countdown = 50;
        }

        if(countdown < 0)
        {
            GetComponent<Animator>().SetBool("Left", false);
            GetComponent<Animator>().SetBool("Right", false);
        }

        //Handle time display
        switch ((GetComponent<Animator>().GetInteger("Level"))) {
            case 0:
                LevelTime.gameObject.GetComponent<TextMeshProUGUI>().SetText(TimeSpan.FromSeconds(scores[0]).Minutes + " : " + TimeSpan.FromSeconds(scores[0]).Seconds.ToString("00"));
                break;

            case 1:
                LevelTime.gameObject.GetComponent<TextMeshProUGUI>().SetText(TimeSpan.FromSeconds(scores[1]).Minutes + " : " + TimeSpan.FromSeconds(scores[1]).Seconds.ToString("00"));
                break;

            case 2:
                LevelTime.gameObject.GetComponent<TextMeshProUGUI>().SetText(TimeSpan.FromSeconds(scores[2]).Minutes + " : " + TimeSpan.FromSeconds(scores[2]).Seconds.ToString("00"));
                break;
        }
    }
}

