using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScene() {
        SceneManager.LoadScene("test");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("menu");
    }
    public void stopTime()
    {
        Time.timeScale = 0f;
    }
    public void Timeplay()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
