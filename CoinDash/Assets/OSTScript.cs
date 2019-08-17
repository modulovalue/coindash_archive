using UnityEngine;
using System.Collections;

public class OSTScript : MonoBehaviour {
	public static OSTScript ost;
	// Use this for initialization
	void Awake()
	{
		if (Application.loadedLevel == 0 || Application.loadedLevel == 2) 
		{
						Destroy (gameObject);
		}
		else if( Application.loadedLevel == 1)
		{
			if (ost == null) {
				DontDestroyOnLoad(gameObject);
				ost = this;
					}
			else if(ost != null)
			{
				Destroy (gameObject);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 0 || Application.loadedLevel == 2) 
		{
			Destroy (gameObject);
		}
	}
}
