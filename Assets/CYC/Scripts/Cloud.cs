using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]Controll input;
    [SerializeField]float rotationSpeed;
    [SerializeField]float sensitive;
    int min, max, i;
    float xRot, yRot, zRot, x,y, wait;
    public float waitTime, startDelay, randomDirectionDelay;
    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        max = 5;
        RandomRot();
        InvokeRepeating("RandomRot", startDelay, randomDirectionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            wait = waitTime;
            RandomRot();
        }
        else
        {
            transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
        }
        if(wait > 0)
        {
            i = 0;
            wait -= Time.deltaTime;
        }
    }

    void RandomRot()
    {
        i = Random.Range(min, max);        
    }

    void Move()
    {
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
