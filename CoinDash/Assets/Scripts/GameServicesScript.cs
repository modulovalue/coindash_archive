using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameServicesScript : MonoBehaviour {
	public GameObject acbutton;
	public static bool gpanim = false ;
	public GameObject achieve;
	public GameObject leader;

	void Awake()
	{
		PlayGamesPlatform.Activate();
//	
//		Activate();

	}
	void Start()
	{

//		Activate();


	}
//	IEnumerator reports()
//	{
//
//		yield return new WaitForSeconds(2.0f);
//			StartCoroutine("reports");
//	}

	public void Activate()
	{

		Social.localUser.Authenticate((bool success) => {

		});
	}

	public void Achievements()
	{

	Social.ShowAchievementsUI();
	
	}



	public void Leaderboard()
	{
		((PlayGamesPlatform) Social.Active).ShowLeaderboardUI("CgkIucChi78ZEAIQAQ");
	}


	public void openInGooglePlay() 
	{
		AchievementScript.AchieveLvlThx();

	Application.OpenURL("market://details?id=com.ModestasV.CoinDash");
	}
	
}
