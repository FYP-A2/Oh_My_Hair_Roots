using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sun : MonoBehaviour
{
    [SerializeField]Controll input;
    [SerializeField] GameObject sunlight;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.getSunIsHold())
        {
            Ray ray = Camera.main.ScreenPointToRay(input.getmPrevPos());
            RaycastHit hit;
            // add layer mask head
            Physics.Raycast(ray, out hit, 1000,layerMask:1<<6);
            // check head
            if (hit.collider != null)
            {
                if (hit.transform.name == "head")
                {
                    newPos = (hit.point - hit.transform.position) * 1.5f;
                    sunlight.SetActive(true);
                    sunlight.transform.position = newPos;
                    sunlight.transform.LookAt(hit.point);
                }
            }
            else
            {
                sunlight.SetActive(false);
            }
        }
        else
        {
            sunlight.SetActive(false);
        }
    }

}
