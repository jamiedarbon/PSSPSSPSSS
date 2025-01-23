using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StateManager : MonoBehaviour
{
    private GameObject[] dontDestroy;
    private GameObject[] cats;

    private int catCount;
    public int scoreTemp = 32;

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        dontDestroy = GameObject.FindGameObjectsWithTag("DontDestroy");
        for (int i = 0; i < dontDestroy.Length; i++)
        {
            DontDestroyOnLoad(dontDestroy[i]);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 0:
                GameObject.Find("Level Select").GetComponent<LevelNavigation>().tempScore = scoreTemp;
                Debug.Log("Scores: " + GameObject.Find("Level Select").GetComponent<LevelNavigation>().scores);
                break;

            default:
                cats = GameObject.FindGameObjectsWithTag("cat");
                catCount = cats.Length;
                GameObject.Find("CatCount").GetComponent<TextMeshProUGUI>().SetText(catCount.ToString());
                GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().playerCanMove = true;
                GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.GetComponent<FirstPersonController>().cameraCanMove = true;
                break;
        }
        
        
    }

}
