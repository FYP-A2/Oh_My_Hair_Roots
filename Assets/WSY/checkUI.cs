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
    public Hair nowHair;

    public GameObject allHairUI;
    public Hair2DUI hair2DUI;


    void Start() {
        hair = FindObjectsOfType<Hair>();

        //slider_hp.SetActive(false);
        //scrollbar_oil.SetActive(false);
        //nowHair = hair[Random.Range(0,hair.Length)];
    }

    void Update()
    {
        if (nowHair == null && allHairUI.activeSelf)
            allHairUI.SetActive(false);
        
        else if (nowHair != null && !allHairUI.activeSelf)
            allHairUI.SetActive(true);

        if (nowHair != null)
            DisplayHairInfo(nowHair);

    }
    
    public void SetNowHair(Hair h)
    {
        nowHair = h;
    }

    void DisplayHairInfo(Hair h)
    {
        hp_bar.value = h.hp;
        oil_bar.value = h.water_oil_balance;
        //i.transform.position = new Vector3(j.transform.position.x - 35f, j.transform.position.y, j.transform.position.z);
        //for (int x = 0; x < 5; x++)
        //{
        //    image[x].SetActive(false);
        //    if (x == h.nowStatus)
        //        image[x].SetActive(true);
        //}

        //send to 2d hair
        hair2DUI.SetAllPara((100 - nowHair.hp) / 100, nowHair.hairglow, nowHair.water_oil_balance, nowHair.Skin);
    }

    //public void addwater(float n)
    //{
    //    hair[nowHair].AddWater(n);
    //}
    //
    //
    //public void Cleanhairskin()
    //{
    //    hair[nowHair].CleanHairSkin();
    //}
    //
    //public void clickUI(int x) {
    //    nowHair= x;
    //}

}
