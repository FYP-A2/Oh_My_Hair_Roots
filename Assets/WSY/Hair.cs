using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
// if respawn hp, oil, glow will reset
public class Hair : MonoBehaviour
{
    public float hp, water_oil_balance, hairglow;
    public float SpeedOfOil, SpeedOfHp, OilAdd, hairSkin, ValueOfHairSkin, glowValue,ValueOfHp, ValueofOil,opTime;
    public bool ungrowable = false,run = true, deadhair= false,health = false;
    public int nowStatus=0;
    public Slider bar_hp;
    public Scrollbar bar_oil;
    public bool Skin = false;


    void Start() {
        Status(nowStatus);
        StartCoroutine(HairOpeningDead());
    }

    void Update()
       {
        if (run)
        {
            if (water_oil_balance >= 1) water_oil_balance = 1;
            if (water_oil_balance <= 0) water_oil_balance = 0;
            if (hairglow >= 1) hairglow = 1;
            if (hairSkin <= 0) hairSkin = 0;
            if ((hairglow >= 1) && (hp >= 75)) { health = true; } else { health = false; }
            Status(nowStatus);
            GotHairSkin();
            if (hp <= 0) ungrowable = true;
            if (ungrowable)
            {
                StartCoroutine(HairOutAnimetion());
            }
        }
        else if (hairSkin <= 0) { RespawnHair(); }
    }

    IEnumerator HairOpeningDead() {

        run = false;
        ungrowable = false;
        if (deadhair)
        {
            Debug.Log("Start animetion_op");// hair out animetion
            ////////////////////////////////////
            yield return new WaitForSeconds(opTime);
            hp = 0;
        }
        else
        {
            yield return new WaitForSeconds(opTime);
            RespawnHair();
        }
        Debug.Log("End animetion_op");
    }

    IEnumerator HairOutAnimetion() {
        run = false;
        ungrowable = false;
        Debug.Log("Start animetion");// hair out animetion
        yield return new WaitForSeconds(opTime); // how the long of that animetion and some cool down
        Debug.Log("End animetion");
    }

    IEnumerator AutoOilIncrease()
    {
        if (!ungrowable&&run)
        {
            water_oil_balance += OilAdd;
            updateHp();
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
                hp += (0.15f - up)*15; // add (0.15-up hp) if x = 0.5 will add 0.15 hp
                hairglow += glowValue;
                break; 
            case 1:
                up = System.Math.Abs(water_oil_balance - 0.35f);
                hp -= (up / 4f)*15;
                break;
            case 2:
                up = System.Math.Abs(water_oil_balance - 0.35f);
                hp -= (up / 2f)*15;
                break;
            case 3:
                hairSkin += water_oil_balance/2f;
                up = (water_oil_balance - 0.65f);
                hp -= (up / 4f)*15;
                break;
            case 4:
                hairSkin += water_oil_balance*1.5f;
                up = (water_oil_balance - 0.65f);
                hp -= (up/2f)*15;
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
        if (run)
            StartCoroutine(AutoOilIncrease());
    }

    public void AddWater(float n) {
        if (!Skin&&run)
        {
            water_oil_balance += -1 * n;
            hairSkin -= (ValueOfHairSkin * 0.01f);
        }
    }

    public void CleanHairSkin() {
         hairSkin = 0;
    }

    public void RespawnHair() {
        run = true;
        hp = ValueOfHp;
        water_oil_balance = ValueofOil;
        hairglow = 0;
        waterAutoDecrease();
    }

}
