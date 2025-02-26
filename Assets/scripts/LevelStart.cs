using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    [SerializeField] GameObject transition;
    private GameObject[] levelSelect;
    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelSelect = GameObject.FindGameObjectsWithTag("LevelSelect");
    }

    public void startLevel()
    {
        Debug.Log("BUTTON PRESSED");
        StartCoroutine(LoadLevel(level));
    }

    // For "return to level select"
    public void toLevelSelect()
    {
        StartCoroutine(LoadLevel(0));
    }

    // Loads specified level
    private IEnumerator LoadLevel(int level)
    {
        transition.GetComponent<Animator>().Play("Transition");
        yield return new WaitForSeconds(1);
        switch (level) {
            default:
                Debug.Log("State 1");
                
                GameObject.Find("GeneralUI").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("GeneralUI").transform.GetChild(0).gameObject.SetActive(false);
                SceneManager.LoadScene(level);
                break;

            case 0:
                Debug.Log("State 0");
                GameObject.Find("GeneralUI").transform.GetChild(2).gameObject.SetActive(false);
                GameObject.Find("GeneralUI").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("GeneralUI").transform.GetChild(0).gameObject.SetActive(true);
                SceneManager.LoadScene(0);
                break;

            case 1:
                Debug.Log("State 1");

                GameObject.Find("GeneralUI").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("GeneralUI").transform.GetChild(0).gameObject.SetActive(false);
                SceneManager.LoadScene(level);
                break;

            case 3:
                Debug.Log("State 3");

                GameObject.Find("GeneralUI").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("GeneralUI").transform.GetChild(0).gameObject.SetActive(false);
                SceneManager.LoadScene(level);
                break;
        }
        
    }

    private void OnLevelWasLoaded(int levelLoad)
    {
        //Set index to 1 if the level select level has been loaded
        if (levelLoad == 0)
        {
            level = 1;
        }
    }
}
