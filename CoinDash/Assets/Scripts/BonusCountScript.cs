using UnityEngine;
using System.Collections;

public class BonusCountScript : MonoBehaviour {

	// Use this for initialization
	void FixedUpdate () {

		UILabel lbl = GetComponent<UILabel>();
		lbl.text ="Bonus: " + CoinScript.bonus.ToString();
	}

}
