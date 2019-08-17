using UnityEngine;
using System.Collections;

public class Tutorial1Script : MonoBehaviour {

	void Awake()
	{
		if (PlayerPrefs.GetString("tutOn", "true") == "true") {
			this.gameObject.SetActive(true);
				}
		else if (PlayerPrefs.GetString("tutOn", "true") == "false") {
			this.gameObject.SetActive(false);
		}
	}

	void OnEnable()
	{
		TextScript.globaltimescale = 0.0f;
	}

	void OnClick()
	{
		TextScript.globaltimescale = 1.0f;
		Time.timeScale = 1.0f;
		Destroy(this.gameObject);
	}
}
