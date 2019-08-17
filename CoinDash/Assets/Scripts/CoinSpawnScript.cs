using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawnScript : MonoBehaviour {
	
	public static double spawnRate ;
	public GameObject Coin;
	public static int coinsOn;
	public static float coinsComplete;
	public GameObject gameOverScreen;
	public GameObject buyBall;
	public GameObject buyBalllbl;
	public static List<GameObject> coins;
	public int numberOfCoins = 150;
	public static string level = "Stage 0" ;
	public static bool wait = false;
	public GameObject pups;

	public GameObject Upgrade;

	bool cancel;

	public static float[] nextlvl = new float[] 
	{
		10,
		30,
		50,
		100,
		200,
		300,
		500,
		700,
		1000,
		2000,
		3000,
		4000,
		5000,
		6000,
		9500,
		12000,
		15000,
		18000,
		23000,
		30000,
		38000,
		50000
	};

	public static GameObject cCoin;
	

	void Awake()
	{
		pups.SetActive(true);
		Upgrade.SetActive(false);
		cancel = true;
		spawnRate = 0.45f;

		WhichLevelScript.levelColor = Color.white;

		coins = new List<GameObject> ();
		for (int i = 0; i < numberOfCoins; i++) 
		{
			GameObject obj = (GameObject)Instantiate (Coin);
			obj.SetActive (false);
			coins.Add (obj);
		}			
			gameOver(false);
			Restart();
			StartSpawning();
	}
	

	public static GameObject GetCleanCoin()
	{
		cCoin = CoinSpawnScript.coins[0];
		CoinSpawnScript.coins.Remove(cCoin);
		cCoin.name = "Coin";
		return cCoin;
	}
	
	public static void PutCoinBack(GameObject bCoin)
	{
			bCoin.SetActive(false);
			CoinSpawnScript.coins.Insert(0,bCoin);
	}


	public static void Restart()
	{

		SphereScript.points = 0;
		level = "Stage 0";
		Time.timeScale = 1.0f;
		coinsOn = 0;
		coinsComplete = 0;
	}

	public void StartSpawning()
	{
		GameObject newCoin = CoinSpawnScript.GetCleanCoin();
		newCoin.name = "Coin";
		newCoin.transform.position = new Vector3(Random.Range(-2.2f,2.2f),Random.Range(-2.2f,2.2f),0f);
		newCoin.collider2D.enabled = true;
		newCoin.SetActive(true);
		coinsOn++;
		Invoke("StartSpawning",(float)spawnRate / Time.timeScale );
	}

	public IEnumerator gameOver(bool go)
	{

		if (go == true) 
		{
			GameObject[] ding = GameObject.FindGameObjectsWithTag("coin");
			GameObject[] dingb = GameObject.FindGameObjectsWithTag("Player");

			foreach(var ball in dingb)
			{
				
				ball.GetComponent<CircleCollider2D>().enabled = false;

			}
			Upgrade.SetActive(true);

			CancelInvoke("StartSpawning");
		
			
			foreach(var ball in dingb)
			{

				ball.GetComponent<TweenPosition>().from = ball.transform.position;
				ball.GetComponent<TweenPosition>().to = new Vector3(ball.transform.position.x,20 + ball.transform.position.y, ball.transform.position.z);
				ball.GetComponent<TweenPosition>().enabled = true;
			}
			yield return new WaitForSeconds(2.0f);

			foreach(var ballb in dingb)
			{

				ballb.GetComponent<TweenPosition>().enabled = false;
				ballb.SetActive(false);


			}

			foreach(var coin in ding)
			{
				SphereScript.points += CoinScript.punkte;
				CoinSpawnScript.coinsComplete++;
				CoinSpawnScript.coinsOn--;
				float tempCM = PlayerPrefs.GetFloat("coinMoney");
				tempCM++;
				PlayerPrefs.SetFloat("coinMoney", tempCM );
				//		StartCoroutine(FadeTo(0.0f, 0.35f));
				//		StartCoroutine(ToMove(3.0f, 0.5f));
				CoinSpawnScript.PutCoinBack(coin);
				CoinScript ss = Coin.GetComponent<CoinScript>();
				ss.spieleSound();

//				csound.gameObject.GetComponent<CoinSoundScript>().playCoin();	
				yield return new WaitForSeconds(0.002f);

			}

			gameOverScreen.SetActive(go);

			yield return null;
		}
	}

	void FixedUpdate()
	{
		if (coinsOn > 128 ) 
		{


			if (cancel == true) 
			{

				cancel = false;
				pups.SetActive(false);
				StartCoroutine(gameOver(true) );

			}

		}


		if (coinsComplete >= nextlvl[0] && !wait) {
				spawnRate = 0.15;
				level = "Stage 1";
				
			if (coinsComplete >= nextlvl[1]) {
					spawnRate = 0.10;
					level = "Stage 2";

	
				if (coinsComplete >= nextlvl[2]) {
						spawnRate = 0.08;
						level = "Stage 3";

					if (coinsComplete >= nextlvl[3]) {


						UISprite ballsprite = buyBall.GetComponent<UISprite>();
						ballsprite.enabled = true;

						UILabel balllbl = buyBalllbl.GetComponent<UILabel>();
						balllbl.enabled = true;

						TweenPosition twan = buyBall.GetComponent<TweenPosition>();
						twan.enabled = true;


							spawnRate = 0.07;
							level = "Stage 4";

						if (coinsComplete >= nextlvl[4]) {
								spawnRate = 0.06;
								level = "Stage 5";
							WhichLevelScript.levelColor = Color.yellow;

							if (coinsComplete >= nextlvl[5]) {
									spawnRate = 0.05;
									level = "Stage 6";
								WhichLevelScript.levelColor = Color.yellow;

								if (coinsComplete >= nextlvl[6]) {
										spawnRate = 0.04;
										level = "Stage 7";
									WhichLevelScript.levelColor = Color.yellow;

									if (coinsComplete >= nextlvl[7]) {
											spawnRate = 0.03;
											level = "Stage 8";
										WhichLevelScript.levelColor = Color.yellow;

										if (coinsComplete >= nextlvl[8]) {
												spawnRate = 0.025;
												level = "Stage 9";
											WhichLevelScript.levelColor = Color.green;

											if (coinsComplete >= nextlvl[9]) {
													spawnRate = 0.021;
													level = "Stage 10";
												WhichLevelScript.levelColor = Color.green;

												if (coinsComplete >= nextlvl[10]) {
													spawnRate = 0.018;
														level = "Stage 11";
													WhichLevelScript.levelColor = Color.green;

													if (coinsComplete >= nextlvl[11]) {
														spawnRate = 0.015;
															level = "Stage 12";
														WhichLevelScript.levelColor = Color.green;

														if (coinsComplete >= nextlvl[12]) {
															spawnRate = 0.0013;
																level = "Stage 13 INSANE";
															WhichLevelScript.levelColor = Color.magenta;

															if (coinsComplete >= nextlvl[13]) {
																spawnRate = 0.0010;
																	level = "Stage 14 KING";
																AchievementScript.AchieveLvlKing();

																WhichLevelScript.levelColor = Color.cyan;

																if (coinsComplete >= nextlvl[14]) {
																	spawnRate = 0.007;
																		level = "Stage 15 GOD ";
																	WhichLevelScript.levelColor = Color.red;

																	if (coinsComplete >= nextlvl[15]) {
																		spawnRate = 0.003;
																			level = "Stage 16 AmazingKING ";
																		WhichLevelScript.levelColor = Color.red;

																		if (coinsComplete >= nextlvl[16]) {
																			spawnRate = 0.001;
																				level = "Stage 17 AmazingGOD ";
																			WhichLevelScript.levelColor = Color.red;

																			if (coinsComplete >= nextlvl[17]) {
																				spawnRate = 0.0003;
																					level = "Stage 18 1 Left Bro";
																				WhichLevelScript.levelColor = Color.red;

																				if (coinsComplete >= nextlvl[18]) {
																					spawnRate = 0.0001;
																						level = "Stage 19 you Won!";
																					WhichLevelScript.levelColor = Color.blue;

																					if (coinsComplete >= nextlvl[19]) {
																						spawnRate = 0.00005;
																							level = "Stage X";
																						AchievementScript.AchieveLvlX();
																						WhichLevelScript.levelColor = Color.grey;
																							
																						if (coinsComplete >= nextlvl[20]) {
																							spawnRate = 0.000002;
																								level = "Stage Y";
																							WhichLevelScript.levelColor = Color.grey;
																							
																								if (coinsComplete >= nextlvl[21]) {
																								spawnRate = 0.00000025;
																									level = "Stage Z";
																								AchievementScript.AchieveLvlZ();
																								WhichLevelScript.levelColor = Color.cyan;
																							}																								
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
	
