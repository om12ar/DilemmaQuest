using UnityEngine;
using System.Collections;

public class openLevell : MonoBehaviour {
	public string LevelName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		Application.LoadLevel(LevelName);

		                     
	

	}
}
