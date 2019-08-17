using UnityEngine;
using System.Collections;

public class AchievementScript : MonoBehaviour {


	static string achievementKing = "CgkIucChi78ZEAIQAg";
	static string achievementWow10k ="CgkIucChi78ZEAIQAw";
	static string achievementSuchHighscore = "CgkIucChi78ZEAIQBA";
	static string achievementStageX = "CgkIucChi78ZEAIQBQ";
	static string achievementStageZ = "CgkIucChi78ZEAIQBg";
	static string achievementThankYou = "CgkIucChi78ZEAIQBw";
	static string achievement5kNice = "CgkIucChi78ZEAIQCA";
	static string achievementNoBallzForYou = "CgkIucChi78ZEAIQCQ";

	public static void AchieveBallzAway()
	{
		Social.ReportProgress(achievementNoBallzForYou, 100.0f, (bool success) => {
			
		});
	}
	public static void Achieve5k()
	{
		Social.ReportProgress(achievement5kNice, 100.0f, (bool success) => {
		
		});
	}
	public static void AchieveLvlThx()
	{
		Social.ReportProgress(achievementThankYou, 100.0f, (bool success) => {
		});
	}
	public static void AchieveLvlZ()
	{
		Social.ReportProgress(achievementStageZ, 100.0f, (bool success) => {

		});
	}
	public static void AchieveLvlX()
	{
		Social.ReportProgress(achievementStageX, 100.0f, (bool success) => {

		});
	}
	public static void AchieveLvlKing()
	{
		Social.ReportProgress(achievementKing, 100.0f, (bool success) => {
		
		});
	}
	public static void Achieve10k()
	{
		Social.ReportProgress(achievementWow10k, 100.0f, (bool success) => {
		
		});
	}
	public static void Achieve20k()
	{
		Social.ReportProgress(achievementSuchHighscore, 100.0f, (bool success) => {
		
		});
	}
}
