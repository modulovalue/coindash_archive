using UnityEngine;
using System.Collections;

public class MoneyTextScript : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		UILabel uilbl = this.GetComponent<UILabel>();
		uilbl.text = ": " + PlayerPrefs.GetFloat("coinMoney") ;

	
	}
}
