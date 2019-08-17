using UnityEngine;
using System.Collections;

public class WhichLevelScript : MonoBehaviour {
	public static Color levelColor = Color.white;
	public GameObject animLvL;
	void Start()
	{
		StartCoroutine("anim");
		UILabel lbl = GetComponent<UILabel>();
		lbl.text = "Stage 0";
		this.GetComponent<TweenRotation>().from.z = 0;
		this.GetComponent<TweenRotation>().to.z = 0;
		this.GetComponent<TweenScale>().to = new Vector3(1,1,1);

	}

	void FixedUpdate () {



		UILabel lbl = GetComponent<UILabel>();
		if(lbl.text != CoinSpawnScript.level)
		{	StartCoroutine("anim");
			this.GetComponent<TweenRotation>().from.z += -1;
			this.GetComponent<TweenRotation>().to.z += 1;
			this.GetComponent<TweenScale>().to += new Vector3(0.1f,0.1f,0.1f);
			lbl.text = CoinSpawnScript.level;
			audio.Play ();
			audio.pitch += 0.05f;

		}
		lbl.color = Color.Lerp(lbl.color, levelColor, 1.5f * Time.deltaTime);

	}


	IEnumerator anim()
	{
		animLvL.SetActive(true);
			yield return new WaitForSeconds(1.3f);
		animLvL.SetActive(false);
	}

}
