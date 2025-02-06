using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutsceneController : MonoBehaviour
{
    public PlayableDirector director;
    public Camera cutsceneCam;
    private GameObject[] cutsceneObjects;
    private GameObject[] gameplayObjects;
    // Start is called before the first frame update
    void Start()
    {
        cutsceneObjects = GameObject.FindGameObjectsWithTag("Open Cutscene");
        gameplayObjects = GameObject.FindGameObjectsWithTag("Gameplay");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(startLevel());
        }
    }

    private IEnumerator startLevel()
    {
        GameObject.Find("GeneralUI").transform.GetChild(4).gameObject.GetComponent<Animator>().Play("StartTransition");
        yield return new WaitForSeconds(1.5f);
        director.enabled = false;
        for (int i = 0; i < cutsceneObjects.Length; i++)
        {
            cutsceneCam.enabled = false;
            cutsceneObjects[i].SetActive(false);
        }
        for (int i = 0; i < gameplayObjects.Length; i++)
        {
            gameplayObjects[i].SetActive(true);
        }
        GameObject.Find("PlayerStore").transform.GetChild(0).gameObject.SetActive(true);
        
    }
}
