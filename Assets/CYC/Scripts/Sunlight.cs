using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour
{
    public float removeWaterAmount = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        HairAround ha;
        if(other.TryGetComponent<HairAround>(out ha))
        {
            ha.myHair.RemoveWater(removeWaterAmount);
        }
    }
}
