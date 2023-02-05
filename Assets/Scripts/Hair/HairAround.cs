using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAround : MonoBehaviour
{
    bool hairAroundRecorded = false;
    public Hair myHair;
    public List<HairAround> hairAround = new List<HairAround>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myHair.deadhair)
            if (CheckOneHealthHairAround())
                myHair.deadhair = false;

        //if (!myHair.deadhair && !myHair.run)
        //    if (CheckOneHealthHairAround())
        //        myHair.run = true;
    }

    IEnumerator SetRecorded()
    {
        yield return null;
        //yield return null;
        //yield return null;

        hairAroundRecorded = true;
    }

    bool CheckOneHealthHairAround()
    {
        foreach (HairAround ha in hairAround)
            if (ha.myHair.health)
                return true;

        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!hairAroundRecorded)
        {
            HairAround ha;
            if (other.TryGetComponent<HairAround>(out ha))
                if (ha != this && !hairAround.Contains(ha))
                    hairAround.Add(ha);
        }
    }
}
