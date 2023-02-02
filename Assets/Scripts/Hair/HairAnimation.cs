using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAnimation : MonoBehaviour
{
    public float grow = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGrow(float n)
    {
        if (n == 1 && grow != 1)
            HairFullGrow();
    }

    void HairFullGrow()
    {
        
    }

    IEnumerator HairFullGrow2()
    {
        yield return null;
    }
}
