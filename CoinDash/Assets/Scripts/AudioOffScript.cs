using UnityEngine;
using System.Collections;

public class AudioOffScript : MonoBehaviour {

	public GameObject ding;
	public GameObject on;
	public GameObject off;

	void Awake()
	{
		if(this.gameObject.name =="CheckerSound")
		{
			if(PlayerPrefs.GetString("audio") == null )
			{
				AudioListener.pause = false;
				on.SetActive(true);
				off.SetActive(false);
			}
			else if(PlayerPrefs.GetString("audio") == "off")
			{
				AudioListener.pause = true;
				on.SetActive(false);
				off.SetActive(true);
			}
		}


	}


	void FixedUpdate()
	{
		if(this.gameObject.name =="CheckerSound")
		{
			if(PlayerPrefs.GetString("audio") == null )
			{
				AudioListener.pause = false;
				on.SetActive(true);
				off.SetActive(false);
			}
			else if(PlayerPrefs.GetString("audio") == "off")
			{
				AudioListener.pause = true;
				on.SetActive(false);
				off.SetActive(true);
			}
		}
	}

	void OnClick()
	{
		if(this.name == "Off")
		{
				PlayerPrefs.SetString("audio",null);
			AudioListener.pause = false;
			ding.SetActive(true);
			this.gameObject.SetActive(false);
		}


		else if(this.name == "On")
		{
				PlayerPrefs.SetString("audio", "off");
			AudioListener.pause = true;
			ding.SetActive(true);
			this.gameObject.SetActive(false);
		}

	}
}
