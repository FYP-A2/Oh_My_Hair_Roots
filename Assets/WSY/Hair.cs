using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Hair : MonoBehaviour
{
    public float hp, water_oil_balance,SpeedOfOil, SpeedOfHp,OilAdd,hairSkin,ValueOfHairSkin;
    public float hairglow,glowValue;
    public bool ungrowable = false;
    public int nowStatus=0;
    public Slider bar_hp;
    public Scrollbar bar_oil;
    public bool Skin = false;


    void Start() {
        StartCoroutine(AutoOilIncrease());
    }

    void Update()
       {
        if (water_oil_balance >= 1) water_oil_balance = 1;
        if (water_oil_balance<=0) water_oil_balance = 0;
        updateHp();
        Status(nowStatus);
        GotHairSkin();
        /*  if (hp<=0)
              ungrowable= true;*/
    }


    IEnumerator AutoOilIncrease()
    {
        if (!ungrowable)
        {
            water_oil_balance += OilAdd;
            if (nowStatus == 0) {
                hairglow += glowValue;
            }
            yield return new WaitForSeconds(SpeedOfOil);
            StartCoroutine(AutoOilIncrease());
        }
    }

    void updateHp() {
        float up;
        switch (nowStatus)
        {
            case 0:
                up = System.Math.Abs(water_oil_balance - 0.5f);// = |x-0.5|
                hp += (0.15f - up)/10; // add (0.15-up hp) if x = 0.5 will add 0.15 hp
                break; 
            case 1:

                break;
            case 2:

                break;
            case 3:
                hairSkin += water_oil_balance/2f;
                break;
            case 4:
                hairSkin += water_oil_balance*1.5f;
                break;
        }
    
    
    }

    void Status(int status)
    {
        if (water_oil_balance >= 0.35f && water_oil_balance <= 0.65f)
        {
            nowStatus = 0;
        }

        if (water_oil_balance > 0.65f && water_oil_balance <= 0.85f)
        {
            nowStatus = 3;
        }

        if (water_oil_balance > 0.85f)
        {
            nowStatus = 4;
        }

        if (water_oil_balance >= 0.15f && water_oil_balance < 0.35f)
        {
            nowStatus = 1;
        }

        if (water_oil_balance <0.15f)
        {
            nowStatus = 2;
        }

    }

    void GotHairSkin() {
        if (hairSkin >= ValueOfHairSkin)
            Skin = true;
        else Skin = false;
    }

    public void waterAutoDecrease() {
        StartCoroutine(AutoOilIncrease());
    }

    public void AddWater(float n) {
        if (!Skin)
        {
            water_oil_balance += -1 * n;
            CleanHairSkin();
        }
    }

    public void CleanHairSkin() {
        hairSkin = 0;
    }

}
