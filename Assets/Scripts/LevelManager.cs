using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public TextMesh coins;
    public TextMesh time;
    public TextMesh health;

    public Image good;    
    public Image evil;

   
    void Start()
    {
        /*
         * health = 50;
        good = 50;
        evil = 50;
        coins = 50;
        time = 0;
         * */
       
        PlayerPrefs.SetInt("coins", 10);
        PlayerPrefs.SetInt("time", 0);
        PlayerPrefs.SetInt("health", 50);
        PlayerPrefs.SetFloat("good", 0.5f);
        PlayerPrefs.SetFloat("evil", 0.5f);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "coins: " + PlayerPrefs.GetInt("coins").ToString();
        //print(PlayerPrefs.GetInt("health"));
        time.text = "days: " + PlayerPrefs.GetInt("time").ToString();
        health.text = "health: " + PlayerPrefs.GetInt("health").ToString();
        evil.fillAmount = PlayerPrefs.GetFloat("evil");
        good.fillAmount = PlayerPrefs.GetFloat("good");
    }
  
}

