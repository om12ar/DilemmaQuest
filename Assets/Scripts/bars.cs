using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class avatarscdript : MonoBehaviour
{

    public Image good;
    public Image evil;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addGood(int amount)
    {
        good.fillAmount += amount;
    }
    public void addEvil(int amount)
    {
        evil.fillAmount += amount;
    }
}
