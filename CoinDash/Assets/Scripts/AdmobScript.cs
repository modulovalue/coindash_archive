using UnityEngine;
using System.Collections;

public class AdmobScript : MonoBehaviour {

	public static AdmobScript ams; 
//	public GameObject gms;
	private const string AD_UNIT_ID = "ca-app-pub-7697603121012240/3258230005";
	private const string INTERSTITIAL_ID = "ca-app-pub-7697603121012240/7602214400";
	private AdMobPlugin admob;
	public bool closed = true;
	public bool hidden = true;

	void Awake () 
	{
	
		if (ams == null)
		{
			DontDestroyOnLoad(this);
			ams = this;
		}
		else if (ams != this)
		{
			Destroy(gameObject);
		}


//		gms.GetComponent<GameServicesScript>().Activate();

		admob = GetComponent<AdMobPlugin>();
		admob.CreateBanner(AD_UNIT_ID, AdMobPlugin.AdSize.BANNER, false, INTERSTITIAL_ID, false);
		admob.RequestAd();
		admob.RequestInterstitial();
	}
	
	void FixedUpdate()
	{

		if(Application.loadedLevel == 0 && Input.GetKeyDown(KeyCode.Escape))
		{
			GameObject.FindGameObjectWithTag("CloseWindow").GetComponent<TweenPosition>().enabled = true;

			if (closed) 
			{
			admob.ShowInterstitial();
				GameObject.FindGameObjectWithTag("CloseWindow").GetComponent<TweenPosition>().Play(true);
			closed = false;

			}
			else if (!closed) 
			{
				GameObject.FindGameObjectWithTag("CloseWindow").GetComponent<TweenPosition>().Play(false);
			closed = true;
			}

		}
		else if (Application.loadedLevel == 1 && Input.GetKeyDown(KeyCode.Escape) ) 
		{
			Application.LoadLevel(0);
			
		}

		if(Application.loadedLevel == 1)
		{
			if(hidden)
			{
				admob.ShowBanner();
				hidden = false;
			}
		}
		else if(Application.loadedLevel == 0)
		{
			if (!hidden) 
			{
				admob.HideBanner();
				hidden = true;
			}
		}	
	}
}
