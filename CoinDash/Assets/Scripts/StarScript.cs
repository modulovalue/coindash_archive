using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {
	public GameObject starone;
	public GameObject startwo;
	public GameObject starthree;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(SphereScript.points < ( PlayerPrefs.GetFloat("highscore") / 3)  )
		{
			starone.SetActive(false);
			startwo.SetActive(false);
			starthree.SetActive(false);
		}
		else if(SphereScript.points < ( PlayerPrefs.GetFloat("highscore") / 3) +  PlayerPrefs.GetFloat("highscore") / 3 )
		{
			starone.SetActive(true);
			startwo.SetActive(false);
			starthree.SetActive(false);
		}

		else if(SphereScript.points < PlayerPrefs.GetFloat("highscore")  )
		{
			starone.SetActive(true);
			startwo.SetActive(true);
			starthree.SetActive(false);
		}
		else if(SphereScript.points >= PlayerPrefs.GetFloat("highscore")  )
		{
			starone.SetActive(true);
			startwo.SetActive(true);
			starthree.SetActive(true);
		}
	}
}
