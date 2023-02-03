using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]Controll input;
    [SerializeField]float rotationSpeed;
    [SerializeField]float sensitive;
    int min, max;
    float xRot, yRot, zRot, x,y;
    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        max = 5;
        RandomRot();
        InvokeRepeating("RandomRot", 15f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (input.getCloudIsHold())
        {
            x = input.getmPostPos().x * sensitive;
            //if(x>rotationSpeed)
            //    x = rotationSpeed;
            y = input.getmPostPos().y * sensitive;
            //if(y>rotationSpeed)
            //    y = rotationSpeed;
            Vector3 right = Vector3.Cross(Camera.main.transform.up, transform.position - Camera.main.transform.position);
            Vector3 up = Vector3.Cross(transform.position - Camera.main.transform.position, right);
            transform.rotation = Quaternion.AngleAxis(-x, up) * transform.rotation;
            transform.rotation = Quaternion.AngleAxis(y, right) * transform.rotation;
            min = 0;
            max = 0;
            RandomRot();
        }
        else
        {
            transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
            min = 0;
            max = 5;
        }

    }

    void RandomRot()
    {
        int i = Random.Range(min, max);
        switch (i)
        {
            case 0:
                xRot = 0;
                yRot = 0;
                zRot = 0;
                break;
            case 1:
                xRot = rotationSpeed;
                yRot = rotationSpeed;
                zRot = rotationSpeed;
                break;
            case 2:
                xRot = 0;
                yRot = 0;
                zRot = rotationSpeed;
                break;
            case 3:
                xRot = 0;
                yRot = rotationSpeed;
                zRot = rotationSpeed;
                break;
            case 4:
                xRot = 0;
                yRot = rotationSpeed;
                zRot = 0;
                break;
            case 5:
                xRot = rotationSpeed;
                yRot = rotationSpeed;
                zRot = 0;
                break;
            case 6:
                xRot = rotationSpeed;
                yRot = 0;
                zRot = 0;
                break;
            default:
                break;
        }
    }
}
