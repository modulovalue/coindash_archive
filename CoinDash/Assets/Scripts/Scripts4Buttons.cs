using UnityEngine;
using System.Collections;

public class Scripts4Buttons : MonoBehaviour {

	void OnClick()
	{
		CoinSpawnScript.Restart();
		Application.LoadLevel(Application.loadedLevel);
	}

}
