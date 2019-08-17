using UnityEngine;
using System.Collections;

public class TutCheckBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString("tutOn", "true") == "true") {
			this.GetComponent<UIToggle>().value = true;
	
		}
		else if (PlayerPrefs.GetString("tutOn", "true") == "false") 
		{
			this.GetComponent<UIToggle>().value = false;
		}
	}

	void Update () 
	{

		if (this.GetComponent<UIToggle>().value == true) 
		{
			PlayerPrefs.SetString("tutOn", "true");
		}
		else if (this.GetComponent<UIToggle>().value == false) 
		{
			PlayerPrefs.SetString("tutOn", "false");
		}
	}
}
