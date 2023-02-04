using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hair2DUI : MonoBehaviour
{
    public GameObject baseLayer;
    public GameObject inflammationLayer1;
    public GameObject inflammationLayer2;
    public GameObject hairLayer1;
    public GameObject hairLayer2;
    public GameObject oilLayer1;
    public GameObject oilLayer2;
    public GameObject oilLayer3;
    public GameObject oilLayer4;
    public GameObject concreteLayer1;

    [Header("Starting Point")]

    public float inflammation1;
    public float inflammation2;
    public float hair1;
    public float hair2;
    public float oil1;
    public float oil2;
    public float oil3;
    public float oil4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setinflammation(float n)
    {
        inflammationLayer1.SetActive(false);
        inflammationLayer2.SetActive(false);

        if (n < inflammation1)
            inflammationLayer1.SetActive(false);
        else if (n < inflammation2)
            inflammationLayer1.SetActive(true);
        else
            inflammationLayer2.SetActive(true);
    }

    public void SetHair(float n)
    {
        hairLayer1.SetActive(false);
        hairLayer2.SetActive(false);

        if (n < hair1)
            hairLayer1.SetActive(false);
        else if (n < hair2)
            hairLayer1.SetActive(true);
        else
            hairLayer2.SetActive(true);
    }

    public void SetOil(float n)
    {
        oilLayer1.SetActive(false);
        oilLayer2.SetActive(false);
        oilLayer3.SetActive(false);
        oilLayer4.SetActive(false);

        if (n < oil1)
            oilLayer1.SetActive(false);
        else if (n < oil2)
            oilLayer1.SetActive(true);
        else if (n < oil3)
            oilLayer2.SetActive(true);
        else if (n < oil4)
            oilLayer3.SetActive(true);
        else
            oilLayer4.SetActive(true);
    }

    public void SetConcrete(bool n)
    {
        if (n)
            concreteLayer1.SetActive(true);
        else
            concreteLayer1.SetActive(false);
    }
}
