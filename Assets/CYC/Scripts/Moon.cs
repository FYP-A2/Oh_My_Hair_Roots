using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField]Controll input;
    [SerializeField]GameObject moonPos;
    public float holdingScale, hitScale, rotationSpeed;
    Vector3 orginPos, orginScale, scale, newPos;
    Rigidbody rb;
    bool moonGetOut;
    //GameObject target;
    //bool hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //orginPos = transform.position;
        orginScale = transform.localScale;
        rb.maxAngularVelocity = rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.getMoonIsHold())
        {
            Ray ray = Camera.main.ScreenPointToRay(input.getmPrevPos());
            RaycastHit hit;
            // add layer mask head
            Physics.Raycast(ray, out hit, 1000, layerMask: 1 << 6);
            // check head
            if (hit.collider != null)
            {               
                if (hit.transform.name == "head")
                {             
                    //scale = orginScale * hitScale;
                    //transform.localScale = scale;
                    scale = orginScale * holdingScale;
                    transform.localScale = scale;                  
                    transform.position = (hit.point + transform.position * 0.06f * scale.y);
                    moonGetOut = true;
                }
            }
            else
            {
                if (moonGetOut)
                {
                    transform.position = moonPos.transform.position;
                    moonGetOut= false;                  
                }
                //transform.position = orginPos;
                scale = orginScale * holdingScale;
                transform.localScale = scale;
            }              
        }
        else
        {
            if (moonGetOut)
            {
                transform.position = moonPos.transform.position;
                moonGetOut = false;
            }
            //transform.position = orginPos;
            transform.localScale = orginScale;          
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "hairSkin")
            {
                Debug.Log("clean oil");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            HairAround ha;
            if (other.gameObject.TryGetComponent<HairAround>(out ha))
            {
                ha.myHair.CleanHairSkin();
            }
        }
    }
}
