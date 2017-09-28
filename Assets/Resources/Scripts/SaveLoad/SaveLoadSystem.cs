using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/saveFile.cd");

        SaveManager saver = new SaveManager();
        saver.coin = CoinManager.coinManager.coin;

        binary.Serialize(fStream, saver);
        fStream.Close();
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/saveFile.cd"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/saveFile.cd", FileMode.Open);

            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            CoinManager.coinManager.coin = saver.coin;
        }
    }
}

[Serializable]
class SaveManager
{
    public int coin;
}
