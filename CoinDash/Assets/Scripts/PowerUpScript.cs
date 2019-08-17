using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour
{
	
	public GameObject[] buttons = new GameObject[6];

	static float[] xxlTimeArrayCost = new float[] {
		200,
		500,
		1000,
		1500,
		3000,
		4700,
		6000,
		7500,
		9000,
		10000,
	};
	float[] xxlTimeArrayValue = new float[] {
		50,
		45,
		40,
		38,
		36,
		34,
		30,
		28,
		24,
		23
	};
	float[] xxlSizeArrayCost = new float[] {
				200,
				400,
				800,
				1500,
				3000,
				4500,
				5500,
				7000,
				8500,
				10000,
			};
	float[] xxlSizeArrayValue = new float[] {
				1f,
				1.1f,
				1.2f,
				1.3f,
				1.35f,
				1.4f,
				1.5f,
				1.6f,
				1.7f,
				1.8f
			};
	float[] xxlDurationArrayCost = new float[] {
		200,
		400,
		800,
		1500,
		3000,
		4500,
		5500,
		7000,
		8500,
		10000,
					};
	float[] xxlDurationArrayValue = new float[] {
		3f,
		4f,
		5,
		6f,
		7f,
		8f,
		9f,
		10f,
		11f,
		12f
	};
	float[] dshTimeArrayCost = new float[] {
		200,
		500,
		1000,
		1500,
		3000,
		4700,
		6000,
		7500,
		9000,
		10000,
	};
	float[] dshTimeArrayValue = new float[] {
		15,
		12,
		11,
		10,
		9,
		8,
		7,
		6,
		5,
		4
	};
	float[] dshSpeedArrayCost = new float[] {
		200,
		400,
		800,
		1500,
		3000,
		4500,
		5500,
		7000,
		8500,
		10000,
		};
	float[] dshSpeedArrayValue = new float[] {
		1.9f,
		2.2f,
		2.5f,
		3.0f,
		3.4f,
		4.0f,
		4.8f,
		5.5f,
		6.2f,
		7.0f
		};
	static float[] clrTimeArrayCost = new float[] {
		200,
		500,
		1000,
		1500,
		3000,
		4700,
		6000,
		7500,
		9000,
		10000,
	};
	float[] clrTimeArrayValue = new float[] {
		85,
		80,
		70,
		60,
		55,
		50,
		45,
		40,
		35,
		30,
	};

	public UILabel[] lblar = new UILabel[6];

	public UILabel[] lblcost = new UILabel[6];
	
	void Awake ()
	{
		int was = 0;
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", xxlTimeArrayCost [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", xxlSizeArrayCost [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", xxlDurationArrayCost [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", dshTimeArrayCost [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", dshSpeedArrayCost [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name + "Cost", clrTimeArrayCost [0]);
			was++;
		}

		was = 0;

		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name, xxlTimeArrayValue [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name, xxlSizeArrayValue [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name, xxlDurationArrayValue [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {		
			PlayerPrefs.SetFloat (buttons [was].name, dshTimeArrayValue [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name, dshSpeedArrayValue [0]);
			was++;
		}
		if (PlayerPrefs.GetFloat (buttons [was].name) == 0) {
			PlayerPrefs.SetFloat (buttons [was].name, clrTimeArrayValue [0]);
			was++;
		}
		was = 0;
	}

	public void UpdateLbl ()
	{


		for (int i = 0; i < lblar.Length; i++) {
			if (PlayerPrefs.GetFloat (buttons [i].name + "Value") == 0) {
				lblcost [i].text = "200";
				lblcost [i].color = Color.white;
				
				lblar [i].text = "Lv. " + (1 + PlayerPrefs.GetFloat (buttons [i].name + "Value"));
				lblar [i].color = Color.white;
			} else if (PlayerPrefs.GetFloat (buttons [i].name + "Value") < 9) {
				lblcost [i].text = PlayerPrefs.GetFloat (buttons [i].name + "Cost").ToString ();
				lblcost [i].color = Color.white;
			
				lblar [i].text = "Lv. " + (1 + PlayerPrefs.GetFloat (buttons [i].name + "Value"));
				lblar [i].color = Color.white;


			} else {
				lblcost [i].text = "Full";
				lblcost [i].color = Color.red;

				lblar [i].text = "Max";
				lblar [i].color = Color.red;


			}
		}

	}

	void GeldAbzug (float wieviel)
	{
		PlayerPrefs.SetFloat ("coinMoney", PlayerPrefs.GetFloat ("coinMoney") - wieviel);
	}

	void FixedUpdate ()
	{

		UpdateLbl ();

		foreach (GameObject btn in buttons) {
			if (PlayerPrefs.GetFloat (btn.name + "Value") < 9) {
				btn.GetComponent<UIButton> ().enabled = true;
				if (PlayerPrefs.GetFloat ("coinMoney") > (PlayerPrefs.GetFloat (btn.name + "Cost"))) {
					btn.GetComponent<UIButton> ().enabled = true;
					btn.GetComponent<UISprite> ().color = Color.green;
				} else {
					btn.GetComponent<UIButton> ().enabled = false;
					btn.GetComponent<UISprite> ().color = Color.red;
				}								

			} else if (PlayerPrefs.GetFloat (btn.name + "Value") >= 9) {
				btn.GetComponent<UIButton> ().enabled = false;
				btn.GetComponent<UISprite> ().color = Color.black;
				btn.GetComponent<UIButton> ().enabled = false;
			}
		}	
	}

	void newPuUp (float arrayCostLess, string name, string Value, float arrayCost, float updateWert)
	{
		float f = PlayerPrefs.GetFloat (Value);


		PlayerPrefs.SetFloat (name, updateWert);


		PlayerPrefs.SetFloat (name + "Cost", arrayCost);

		PlayerPrefs.SetFloat ("coinMoney", PlayerPrefs.GetFloat ("coinMoney") - arrayCostLess);
		f++;
		PlayerPrefs.SetFloat (Value, f);
		this.audio.Play();

	}

	public void xxlTime ()
	{	
		int btnnr = 0;
		newPuUp (xxlTimeArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", xxlTimeArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], xxlTimeArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}

	public void xxlSize ()
	{
		int btnnr = 1;
		newPuUp (xxlSizeArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", xxlSizeArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], xxlSizeArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}

	public void xxlDuration ()
	{
		int btnnr = 2;
		newPuUp (xxlDurationArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", xxlDurationArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], xxlDurationArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}

	public void dshTime ()
	{
		int btnnr = 3;
		newPuUp (dshTimeArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", dshTimeArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], dshTimeArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}

	public void dshSpeed ()
	{
		int btnnr = 4;
		newPuUp (dshSpeedArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", dshSpeedArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], dshSpeedArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}

	public void clrTime ()
	{
		int btnnr = 5;
		newPuUp (clrTimeArrayCost [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], buttons [btnnr].name, buttons [btnnr].name + "Value", clrTimeArrayCost [1 + (int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")], clrTimeArrayValue [(int)PlayerPrefs.GetFloat (buttons [btnnr].name + "Value")]);
		WhichVarUp (btnnr, buttons [btnnr].name);
	}
	
	public void WhichVarUp (int i, string temp)
	{
	
		if (i == 0) {
			XxlPowerup.xxlTime = PlayerPrefs.GetFloat (temp);	
		} else if (i == 1) {
			XxlPowerup.xxlBallSize = PlayerPrefs.GetFloat (temp);	
		} else if (i == 2) {
			XxlPowerup.xxlDuration = PlayerPrefs.GetFloat (temp);
		} else if (i == 3) {
			XxlPowerup.dshTime = PlayerPrefs.GetFloat (temp);			

		} else if (i == 4) {
			XxlPowerup.dshSpeed = PlayerPrefs.GetFloat (temp);		
			
		} else if (i == 5) {
			XxlPowerup.clrTime = PlayerPrefs.GetFloat (temp);
			
		}
	}

	[ContextMenu ("reset")]
	void reset ()
	{
		PlayerPrefs.DeleteAll ();
	}
	
	[ContextMenu ("add Money")]
	void addmoney ()
	{
		PlayerPrefs.SetFloat ("coinMoney", 200000f);
	}

}
