using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]
    private GameObject IGTimer;
    private bool paused = false;
    private bool levelComplete = false;
    private GameObject[] cats;

    private int catCount;
    public int petted;
    private bool allCats;

    [SerializeField] GameObject endScreen;

    private float Timer;

    private void Start()
    {
        petted = 0;
        cats = GameObject.FindGameObjectsWithTag("cat");
        catCount = cats.Length;

        Debug.Log(catCount + " cats in the level.");
    }
    private void Awake()
    {
        Debug.Log("Started");
        Timer = 0;
        endScreen = GameObject.Find("GeneralUI").gameObject.transform.GetChild(1).gameObject;
        GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().playerCanMove = true;
        GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().cameraCanMove = true;
        Debug.Log(endScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            if(!levelComplete)
            {
                Timer += Time.deltaTime;
                int seconds = (int)Timer % 60;

                IGTimer.GetComponent<TextMeshProUGUI>().SetText(seconds.ToString());
            }
        }

        if(petted == catCount)
        {
            allCats = true;
        }

        if(allCats)
        {
            allCats = false;
            petted++;
            endLevel();
        }
    }

    private void endLevel()
    {
        endScreen.SetActive(true);
        GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().playerCanMove = false;
        GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().cameraCanMove = false;
        GameObject.Find("StateManager").GetComponent<StateManager>().scoreTemp = (int)Timer % 60;
        Debug.Log("Timer converted: " + GameObject.Find("StateManager").GetComponent<StateManager>().scoreTemp);
        Cursor.lockState = CursorLockMode.None;
        levelComplete = true;
    }
}
