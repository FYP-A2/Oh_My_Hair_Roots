using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkUI : MonoBehaviour
{
    public Hair[] hair;
    public Slider hp_bar;
    public Scrollbar oil_bar;
    public GameObject slider_hp, scrollbar_oil,i, j; // i = status, j = handle
    public GameObject[] image;
    int nowHair;


    void Start() {
        slider_hp.SetActive(false);
        scrollbar_oil.SetActive(false);
        nowHair= 0;
    }

    void Update()
    {
        hp_bar.value = hair[nowHair].hp;
        oil_bar.value = hair[nowHair].water_oil_balance;
        i.transform.position = new Vector3(j.transform.position.x - 40f, j.transform.position.y - 5f, j.transform.position.z);
        for (int x = 0; x < 5; x++)
        {
            image[x].SetActive(false);
            if (x == hair[nowHair].nowStatus)
                image[x].SetActive(true);
        }
    }

    public void addwater(float n)
    {
        hair[nowHair].AddWater(n);
    }


    public void Cleanhairskin()
    {
        hair[nowHair].CleanHairSkin();
    }

    public void clickUI(int x) {
        nowHair= x;
    }

}
