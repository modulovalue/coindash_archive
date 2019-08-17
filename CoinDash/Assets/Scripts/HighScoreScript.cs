using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {


	void FixedUpdate () {

		UILabel lbl = this.GetComponent<UILabel>();

		lbl.text = ": " + PlayerPrefs.GetFloat("highscore");

		if (PlayerPrefs.GetFloat("highscore") < SphereScript.points )
		{

			lbl.color = Color.red;
			PlayerPrefs.SetFloat("highscore", (int)SphereScript.points);
		}
	}
}
