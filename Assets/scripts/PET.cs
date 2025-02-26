using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PET : MonoBehaviour
{
    [SerializeField]
    private GameObject hands;
    public Material hands1, hands2;

    private bool clicked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //hands.GetComponent<MeshRenderer>().material = hands2;
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    Debug.Log("Hit");
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }

        if (clicked)
        {
            hands.GetComponent<MeshRenderer>().material = hands2;
        } else
        {
            hands.GetComponent<MeshRenderer>().material = hands1;
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "cat")
        {
            Debug.Log("petpetpet");
            gameObject.GetComponent<ParticleSystem>().Emit(1);
            gameObject.GetComponent<AudioSource>().Play();
            if (gameObject.GetComponentInChildren<Cat>().hasBeenPet == false)
            {
                gameObject.GetComponentInChildren<Cat>().hasBeenPet = true;
                GetComponent<timer>().petted += 1;
            }
        }
    }
}
