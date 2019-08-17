using UnityEngine;
using System.Collections;

public class CloseDialogScript : MonoBehaviour {

	public GameObject yes;
	public GameObject no;
	public GameObject interAd;
	public AdmobScript adi;
	
	public void closedialog()
	{
		TweenPosition tp = this.gameObject.GetComponent<TweenPosition>();
		adi.closed = true;
		tp.Play(false);
	}

	public void closegame()
	{
		Application.Quit();
	}


}
