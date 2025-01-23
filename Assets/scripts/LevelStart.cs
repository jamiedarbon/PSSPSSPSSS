using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    [SerializeField] GameObject transition;
    private GameObject[] levelSelect;
    // Start is called before the first frame update
    void Start()
    {
        levelSelect = GameObject.FindGameObjectsWithTag("LevelSelect");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void level(int level)
    {
        Debug.Log("BUTTON PRESSED");
        StartCoroutine(LoadLevel(level));
    }

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
                SceneManager.LoadScene(level);
                break;
        }
        
    }
}
