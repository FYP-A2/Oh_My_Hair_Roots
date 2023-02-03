using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAutoTransform : MonoBehaviour
{
    public float yOffset = -0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AutoTransform(Vector3 center)
    {
        //Vector3 direction = transform.position - center;
        
        transform.LookAt(center);
        transform.Rotate(new Vector3(-90, 0, 0));


        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yOffset, transform.localPosition.z);
    }
}
