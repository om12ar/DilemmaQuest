using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour {

	private static audioManager instance = null;
	public static audioManager Instance {
		get { return instance; }
	}

	public static audioManager audioMgr;
	bool isMuted;

	public bool IsMuted {
		get {
			return isMuted;
		}
		set {
			AudioSource [] sounds = GetComponents<AudioSource>();
			if(value)
			{
				if(GetComponent<AudioSource>().enabled)
				{
					foreach(AudioSource sound in sounds)
					{
						sound.enabled = false;
						//audioManager.audioMgr.GetComponents<AudioSource>()[0].Pause();
					}
				}
			}
			else
			{
				if(!GetComponent<AudioSource>().enabled)
				{
					foreach(AudioSource sound in sounds)
					{
						sound.enabled = true;
						//audioManager.audioMgr.GetComponents<AudioSource>()[0].Play();
					}
				}
			}
			isMuted = value;
		}
	}

	void Awake() {
		if(!audioMgr)
			audioMgr = this;

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
