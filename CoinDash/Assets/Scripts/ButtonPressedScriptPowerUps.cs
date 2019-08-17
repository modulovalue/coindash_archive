using UnityEngine;
using System.Collections;

public class ButtonPressedScriptPowerUps : MonoBehaviour {

	public static ButtonPressedScriptPowerUps gamecontroler;

	void Awake()
	{
		if (gamecontroler == null) {
			DontDestroyOnLoad(this);
			
			gamecontroler = this;
		}
		else if (gamecontroler != null) {
			Destroy(gameObject);
		}
	}

	public void UpdatePus () 
	{
	
//		for (int i = 0; i < PowerUpScript.buttons[].Length; i++) {
//		}
//		PowerUpScript.buttons[i].GetComponent<XxlPowerup>(). = PlayerPrefs.GetFloat(PowerUpScript.buttons[i].name);	


//		XxlPowerup.puManager.xxlTime = PlayerPrefs.GetFloat("xxlTime");		
//
//		XxlPowerup.puManager.xxlBallSize = PlayerPrefs.GetFloat("xxlBallSize");		
//		XxlPowerup.puManager.xxlDuration = PlayerPrefs.GetFloat("xxlDuration");	  			
//		
//		
//		XxlPowerup.puManager.dshTime = PlayerPrefs.GetFloat("dshTime");			
//
//		XxlPowerup.puManager.dshSpeed = PlayerPrefs.GetFloat("dshSpeed");		
//
//		XxlPowerup.puManager.clrTime = PlayerPrefs.GetFloat("clrTime");			
	}
	public void UpdatePref(string temp, float tempf)
	{
		PlayerPrefs.SetFloat(temp, tempf);
	}
}
