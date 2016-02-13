using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class Level1 {
    
	// Use this for initialization
    public static bool wellOption = false;
    public static bool leaderOption = false;
    public static int numOptions = 7;
    public static List<bool> options = new List<bool>();
    public static Player p1;
    static LevelManager lm;
    public static void start()
    {
        //Load from Player Prefs
        //else

        lm = new LevelManager();
        p1 = new Player();
        
        for (int i = 0; i < numOptions; i++)
        {
            
            options.Add(false);
        }
    }
    public static void choose(int option)
    {

        //0 well
        //1 tribe leader
        //2 cut finger
        //3 buy Saw
        //4 steal house
        //5 cave


        if (option == 0)
        {

            if (!p1.hasItem("water"))
            {
                PlayerPrefs.SetInt("health", PlayerPrefs.GetInt("health") - 3);
                p1.AddItem(new Item("water", 1));
            }

            else
            {
                
                Application.LoadLevel("outro");
            }
        }
        if (option == 1)
        {
            PlayerPrefs.SetFloat("evil", PlayerPrefs.GetFloat("evil") +0.3f);
            PlayerPrefs.SetFloat("good", PlayerPrefs.GetFloat("good") + 0.1f);

        }
        if (option == 2)
        {
            PlayerPrefs.SetFloat("evil", PlayerPrefs.GetFloat("evil") + 0.1f);
            PlayerPrefs.SetFloat("good", PlayerPrefs.GetFloat("good") + 0.1f);
        }
        if (option == 3)
        {
            
            PlayerPrefs.SetFloat("coins", 40);
            p1.AddItem(new Item("saw", 1));
        }
        if (option == 4)
        {
            PlayerPrefs.SetFloat("evil", PlayerPrefs.GetFloat("evil") + 0.2f);
            p1.AddItem(new Item("saw", 1));
        }
        if (option == 5)
        {
            PlayerPrefs.SetFloat("day", PlayerPrefs.GetFloat("day") + 1);
            p1.AddItem(new Item("saw", 1));

        }
        if (option == 6)
        {
            p1.AddItem(new Item("wood", 1));
        }
    }
	
	
}
