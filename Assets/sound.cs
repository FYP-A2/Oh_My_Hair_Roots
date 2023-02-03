using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Press()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted =false;
            AudioListener.pause =false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
