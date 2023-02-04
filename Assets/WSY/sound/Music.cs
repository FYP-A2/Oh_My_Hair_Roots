using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioClip BGM, click,rain,exp;
    public AudioClip[] scream;
    public AudioSource BGMSource, RainSource,ScreamSource, ClickSource,ExpSource;
    public bool OffBgm= false, OffSE= false, stoprain = false;
    public GameObject gaameObject;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void PlayBGM() {
        BGMSource.clip = BGM;
        BGMSource.Play();
    }
    public void Playboom() {
        ExpSource.clip = exp;
        ExpSource.Play();
    }

    public void RandomScream() {
        int x = Random.Range(0,3);
        Debug.Log(x);
        ScreamSource.clip = scream[x];
        ScreamSource.Play();
    }

    public void PlayRain() {
        RainSource.clip = rain;
        RainSource.Play();
        stoprain= false;
    }

    public void StopRain() {
        RainSource.clip = rain;
        stoprain= true;
    }

    public void Click() {
        ClickSource.clip = click;
        ClickSource.Play();

    }

    public void OnOffBGM() {
        OffBgm = !OffBgm;
    }

    public void OnOffSE()
    {
        OffSE= !OffSE;
    }

    public void updataSE(bool check) {
        if (stoprain)
            RainSource.mute = true;
        else RainSource.mute = check;

        ScreamSource.mute = check;
        ClickSource.mute = check;
        ExpSource.mute = check;
    }

    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        if (!OffBgm)
        { BGMSource.mute = false; }
        else { BGMSource.mute = true; }

            if (!OffSE)
                updataSE(false);
            else updataSE(true);
    }
}
