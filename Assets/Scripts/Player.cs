using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player {

    public int health;
    public int good;
    public int evil;
    public int coins;
    public int time;
    List<Item> inventory;

    public Player()
    {
        inventory = new List<Item>();
        health = 50;
        good = 50;
        evil = 50;
        coins = 50;
        time = 0;
    }
    public void AddItem(Item i)
    {
        inventory.Add(i);
    }
    public bool hasItem(string n)
    {
        
        int index = inventory.FindIndex(i => i.name.Equals(n));
        if (index >= 0)
            return true;
        return false;
    }
    public void removeItem(string n)
    {
        int index = inventory.FindIndex(i => i.name==n);

        if (index >= 0)
            inventory.RemoveAt(index);
    }
}
