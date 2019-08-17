using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

//	public static GameControl control;
//
//
//	void Awake () 
//	{
//		if(control == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			control = this;
//		}
//		else if (control != this) 
//		{
//			Destroy(gameObject);
//		}
//	}


//	public void Save()
//	{
//		BinaryFormatter bf = new BinaryFormatter();
//		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.mv");
//
//		PlayerData data = new PlayerData();
////		data.highscore = blabla;
//
//		bf.Serialize(file,data);
//		file.Close();
//
//	}
//    [ContextMenu("Attack!")]
//	public void Load()
//	{
//		if (File.Exists(Application.persistentDataPath + "/playerInfo.mv")) 
//		{
//			BinaryFormatter bf = new BinaryFormatter();
//			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.mv", FileMode.Open);
//			PlayerData data = (PlayerData)bf.Deserialize(file);
//			file.Close();

//			blabla = data.highscore;


//		}
//}
//
//[Serializable]
//class PlayerData
//{
//	public float highscore;
//	public float coinMoney;
}