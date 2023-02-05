using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public List<Hair> hairList = new List<Hair>();
    public static int life = 3;
    public GameObject gameoverUI;
    public GameObject lifeUI;
    public GameObject healthyHairCountUI;
    public GameObject hInfo;
    public GameObject startUI;

    public bool isGameStart = false;


    // Start is called before the first frame update
    void Start()
    {
        hairList = FindObjectsOfType<Hair>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            lifeUI.GetComponent<Text>().text = "Life: " + life;
            healthyHairCountUI.GetComponent<Text>().text = "Healthy Hair: " + GetHealthyHairCount() + "/" + hairList.Count;

            if (GetHealthyHairCount() == hairList.Count)
                Gameover(true);

            if (life <= 0)
                Gameover(false);
        }



    }

    public static void LifeDecrease(int n)
    {
        life -= n;
    }

    public void Gameover(bool win)
    {
        life = 0;

        HideAllUI();
        gameoverUI.SetActive(true);

        if (win)
        {
            gameoverUI.transform.GetChild(0).GetComponent<Text>().text = "You saved all of his hair!!";
            gameoverUI.transform.GetChild(1).GetComponent<Text>().text = "Healthy Hair: " + GetHealthyHairCount() + "/" + hairList.Count;
        }
        else
        {
            gameoverUI.transform.GetChild(0).GetComponent<Text>().text = "You saved part of his hair!!";
            gameoverUI.transform.GetChild(1).GetComponent<Text>().text = "Healthy Hair: " + GetHealthyHairCount() + "/" + hairList.Count;
        }

        Time.timeScale = 0;
    }

    int GetHealthyHairCount()
    {
        int count = 0;
        foreach (Hair hair in hairList)
            if (hair.health)
                count++;

        return count;
    }

    void HideAllUI()
    {
        startUI.SetActive(false);
        hInfo.SetActive(false);
        lifeUI.SetActive(false);
        healthyHairCountUI.SetActive(false);
        gameoverUI.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(StartingGame());

        Debug.Log("start game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartingGame()
    {
        HideAllUI();


        yield return new WaitForSeconds(0.7f);


        foreach (Hair hair in hairList)
            hair.HairStart();

        yield return new WaitForSeconds(3f);

        isGameStart = true;

        lifeUI.SetActive(true);
        healthyHairCountUI.SetActive(true);
    }
}
