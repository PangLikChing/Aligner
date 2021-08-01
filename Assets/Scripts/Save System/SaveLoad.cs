using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    //Initialize
    GameManager gameManager;
    Player player;

    void Awake()
    {
        //Initialize
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.GetComponent<Player>();

        //See if save folder exists
        SaveSystem.Init();
    }

    public void Save()
    {
        string playerName = player.playerName;
        int playerLevel = player.playerLevel;
        int playerExperience = player.playerExperience;
        int playerHoldSkillLevel = player.playerHoldSkillLevel;
        int playerShieldSkillLevel = player.playerShieldSkillLevel;
        int playerSlowSkillLevel = player.playerSlowSkillLevel;
        int flappyBirdHighScore = player.flappyBirdHighScore;

        //Define the SaveObject being saved
        SaveObject saveObject = new SaveObject
        {
            playerName = playerName,
            playerLevel = playerLevel,
            playerExperience = playerExperience,
            playerHoldSkillLevel = playerHoldSkillLevel,
            playerShieldSkillLevel = playerShieldSkillLevel,
            playerSlowSkillLevel = playerSlowSkillLevel,
            flappyBirdHighScore = flappyBirdHighScore,
        };

        string json = JsonUtility.ToJson(saveObject);

        //Save the SaveObject
        SaveSystem.Save(json);
    }

    public bool Load()
    {
        //Load the save file
        string saveString = SaveSystem.Load();

        //If saveString exists
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            //Set Player Name
            player.SetName(saveObject.playerName);
            //Set Player Level
            player.SetLevel(saveObject.playerLevel);
            //Set Player Experience
            player.SetPlayerExperience(saveObject.playerExperience);
            //Set Player Player Hold Skill Level
            player.SetPlayerHoldSkillLevel(saveObject.playerHoldSkillLevel);
            //Set Player Player Shield Skill Level
            player.SetPlayerShieldSkillLevel(saveObject.playerShieldSkillLevel);
            //Set Player Player Slow Skill Level
            player.SetPlayerSlowSkillLevel(saveObject.playerSlowSkillLevel);
            //Set Flappy Bird High Score
            player.SetFlappyBirdHighScore(saveObject.flappyBirdHighScore);

            return true;
        }
        else
        {
            Debug.Log("No Save");

            return false;
        }
    }

    //Define SaveObject Class
    private class SaveObject {
        public string playerName;
        public int playerLevel;
        public int playerExperience;
        public int playerHoldSkillLevel;
        public int playerShieldSkillLevel;
        public int playerSlowSkillLevel;
        public int flappyBirdHighScore;
    }
}
