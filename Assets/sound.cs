using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{
    public Image nowImage;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
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
            nowImage.sprite = soundOffIcon;
        }
        else
        {
            muted =false;
            AudioListener.pause =false;
            nowImage.sprite = soundOnIcon;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
