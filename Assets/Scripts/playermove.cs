using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class playermove : MonoBehaviour {

	Vector2 movement;
	bool jump;
	int score;
    int option;
    
	Sprite mainframe;
    public Transform target;
    public LevelManager lm;
    
//	public avatarscdript gameui ;
	public int health;
	// Use this for initialization
	void Start () {
        
        Level1.start();
        option = -1;
            mainframe = GetComponent<SpriteRenderer>().sprite;
        //player = GetComponent<Transform>().Rotate;
		score = 0;
		//movement=new Vector2(-4f,0);
	}
	// Update is called once per frame
	void Update () {

        
		if (Input.GetKey (KeyCode.RightArrow)) {
            target.transform.eulerAngles = new Vector2(0, 0);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (5f, GetComponent<Rigidbody2D> ().velocity.y);
           GetComponent<Animator> ().enabled = true;
           
            

		} else if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.eulerAngles = new Vector2(0, 180);
            
            

            
            

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5f, GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Animator> ().enabled = true;
            GetComponent<Animator>().transform.Rotate(0, 0, 0);

		} else {
			if(!jump)
			{
				GetComponent<Animator>().enabled=false;
				GetComponent<SpriteRenderer> ().sprite = mainframe;
			}

		}
		 if (Input.GetKey (KeyCode.Space) && !jump) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 7f);
			jump = true;
			GetComponent<Animator> ().enabled = true;
			GetComponent<Animator>().SetTrigger("isjump");
			GetComponent<Animator>().enabled=false;
		}
         if(Input.GetKeyDown(KeyCode.E) && option != -1 && Level1.options[option]!=true)
         {
             Level1.options[option] = true;
  //           Sprite s = Resources.Load<Sprite>("Sprites/done");
//             GameObject.Find("wellsign").GetComponent<SpriteRenderer>().sprite = s;
             Level1.choose(option);
         }

	}
	
    //0 well
    //1 tribe leader
    //2 cut finger
    //3 buy Saw
    //4 steal house
    //5 cave
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag.Equals("well") && Level1.options[0]!=true) 
		{

            GameObject.Find("wellsign").GetComponent<SpriteRenderer>().enabled = true;
            print("WELL");
            option = 0;
		}
        if (other.gameObject.tag.Equals("goodGuy") )
        {
            audioManager.audioMgr.GetComponents<AudioSource>()[1].Play();
            GameObject.Find("goodGuySign").GetComponent<SpriteRenderer>().enabled = true;
            print("GG");
            
        }
        if (other.gameObject.tag.Equals("badGuy") )
        {
            audioManager.audioMgr.GetComponents<AudioSource>()[1].Play();
            GameObject.Find("badGuySign").GetComponent<SpriteRenderer>().enabled = true;
            print("bG");
         
        }
        if (other.gameObject.tag.Equals("leaderHouse") && Level1.options[1] != true) 
		{

            GameObject.Find("killLeader").GetComponent<SpriteRenderer>().enabled = true;
            print("killLeader");
            option = 1;
		}
        if (other.gameObject.tag.Equals("stealHouse") && Level1.options[1] != true)
        {

            GameObject.Find("stealHouseSign").GetComponent<SpriteRenderer>().enabled = true;
            print("killLeader");
            option = 4;
        }
        if (other.gameObject.tag.Equals("treeGuy"))
        {
            audioManager.audioMgr.GetComponents<AudioSource>()[1].Play();
            GameObject.Find("treeGuySign").GetComponent<SpriteRenderer>().enabled = true;
            print("TG");

        }
        if (other.gameObject.tag.Equals("Woman"))
        {
            audioManager.audioMgr.GetComponents<AudioSource>()[1].Play();
            if (Level1.p1.hasItem("water"))
            {
                GameObject.Find("WomanWaterSign").GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GameObject.Find("WomanSign").GetComponent<SpriteRenderer>().enabled = true;
                option = 2;
            }


        }
        if (other.gameObject.tag.Equals("tree"))
        {
            print(Level1.p1.hasItem("saw"));
            if (Level1.p1.hasItem("saw"))
            {
                GameObject.Find("cutTreeSign").GetComponent<SpriteRenderer>().enabled = true;
                option = 6;
                print(Level1.p1.hasItem("saw"));
            }
            


        }
        if (other.gameObject.tag.Equals("fireGuy"))
        {
            audioManager.audioMgr.GetComponents<AudioSource>()[1].Play();
            GameObject.Find("fireGuySign").GetComponent<SpriteRenderer>().enabled = true;
            print("TG");

        }
        if (other.gameObject.tag.Equals("saw"))
        {


            GameObject.Find("sawSign").GetComponent<SpriteRenderer>().enabled = true;
            option = 3;
            print("TG");

        }
        if (other.gameObject.tag.Equals("cave"))
        {

            GameObject.Find("caveSign").GetComponent<SpriteRenderer>().enabled = true;
            print("TG");

        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("ground"))
        {
            jump = false;
            //print("hi");
        }
       
      
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("well"))
        {

            GameObject.Find("wellsign").GetComponent<SpriteRenderer>().enabled = false;
            option = -1;
        }
        if (other.gameObject.tag.Equals("goodGuy"))
        {

            GameObject.Find("goodGuySign").GetComponent<SpriteRenderer>().enabled = false;
         
        }
        if (other.gameObject.tag.Equals("badGuy"))
        {

            GameObject.Find("badGuySign").GetComponent<SpriteRenderer>().enabled = false;
         
        }
        if (other.gameObject.tag.Equals("stealHouse"))
        {

            GameObject.Find("stealHouseSign").GetComponent<SpriteRenderer>().enabled = false;
            option = -1;

        }
        if (other.gameObject.tag.Equals("leaderHouse"))
        {

            GameObject.Find("killLeader").GetComponent<SpriteRenderer>().enabled = false;
            option = -1;
        }
        if (other.gameObject.tag.Equals("treeGuy"))
        {

            GameObject.Find("treeGuySign").GetComponent<SpriteRenderer>().enabled = false;
            
        }
        if (other.gameObject.tag.Equals("Woman"))
        {

            if (Level1.p1.hasItem("water"))
            {
                GameObject.Find("WomanWaterSign").GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GameObject.Find("WomanSign").GetComponent<SpriteRenderer>().enabled = false;
                option = -1;
            }

        }
        if (other.gameObject.tag.Equals("tree"))
        {
           
                GameObject.Find("cutTreeSign").GetComponent<SpriteRenderer>().enabled = false;
                option = -1;
                
            



        }
        if (other.gameObject.tag.Equals("tree") && Level1.p1.hasItem("saw"))
        {

            
                GameObject.Find("WomanWaterSign").GetComponent<SpriteRenderer>().enabled = false;
            

        }
        if (other.gameObject.tag.Equals("fireGuy"))
        {

            GameObject.Find("fireGuySign").GetComponent<SpriteRenderer>().enabled = false;
            print("TG");

        }
        if (other.gameObject.tag.Equals("saw"))
        {

            GameObject.Find("sawSign").GetComponent<SpriteRenderer>().enabled = false;
            option = -1;
            if (Level1.p1.hasItem("saw")) ;
            other.GetComponent<SpriteRenderer>().enabled = false;
            print("TG");

        }
        if (other.gameObject.tag.Equals("cave"))
        {

            GameObject.Find("caveSign").GetComponent<SpriteRenderer>().enabled = false;
            print("TG");

        }
    }
	IEnumerator die()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (Application.loadedLevel);
	}
		}
