using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairParticleReceiver : MonoBehaviour
{
    public Hair hair;
    public float addWaterAmount;


    void OnParticleCollision(GameObject other)
    {
        if (other.name == "RainParticle")
            hair.AddWater(addWaterAmount);
    }

}
