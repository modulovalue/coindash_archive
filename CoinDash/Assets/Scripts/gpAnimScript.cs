using UnityEngine;
using System.Collections;

public class gpAnimScript : MonoBehaviour {

	public GameObject go;
	void Awake()
	{

	}
	public void OnClick()
	{



		var ding = go.GetComponent<GameServicesScript>();
		ding.Activate();

		UIPlayTween uipt = this.GetComponent<UIPlayTween>();
		uipt.Play(true);

		Social.ReportScore((int)PlayerPrefs.GetFloat("highscore"), "CgkIucChi78ZEAIQAQ", (bool success) => {
		});
	}

// 		Update is called once per frame
//	public void activateGpAnim () {
//	
//		if (GameServicesScript.gpanim == true) 
//		{
//			UIPlayTween uipt = this.GetComponent<UIPlayTween>();
//			uipt.Play (true);
//		}
//		else if(GameServicesScript.gpanim == false)
//		{	
//			UIPlayTween uipt = this.GetComponent<UIPlayTween>();
//			uipt.enabled = false;
//		}
//	}
}
