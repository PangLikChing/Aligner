using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Player : MonoBehaviour
{
    //Initialize
    public string playerName;
    public int playerLevel;
    public int playerExperience;
    public int playerHoldSkillLevel;
    public int playerShieldSkillLevel;
    public int playerSlowSkillLevel;
    public int flappyBirdHighScore;

    //Set Player Name
    public void SetName(string name)
    {
        playerName = name;
    }

    //Return Player Name
    public string GetName()
    {
        return playerName;
    }

    //Set Player Level
    public void SetLevel(int level)
    {
        playerLevel = level;
    }

    //Return Player Level
    public int GetLevel()
    {
        return playerLevel;
    }

    //Set Player Experience
    public void SetPlayerExperience(int experience)
    {
        playerExperience = experience;
    }

    //Return Player Experience
    public int GetPlayerExperience()
    {
        return playerExperience;
    }

    //Set Player Hold Skill Level
    public void SetPlayerHoldSkillLevel(int holdSkillLevel)
    {
        playerHoldSkillLevel = holdSkillLevel;
    }

    //Set Player Hold Skill Level
    public int GetPlayerHoldSkillLevel()
    {
        return playerHoldSkillLevel;
    }

    //Set Player Shield Skill Level
    public void SetPlayerShieldSkillLevel(int shieldSkillLevel)
    {
        playerShieldSkillLevel = shieldSkillLevel;
    }

    //Get Player Shield Skill Level
    public int GetPlayerShieldSkillLevel()
    {
        return playerShieldSkillLevel;
    }

    //Set Player Slow Skill Level
    public void SetPlayerSlowSkillLevel(int slowSkillLevel)
    {
        playerSlowSkillLevel = slowSkillLevel;
    }

    //Get Player Slow Skill Level
    public int GetPlayerSlowSkillLevel()
    {
        return playerSlowSkillLevel;
    }

    //Set FlappyBird High Score
    public void SetFlappyBirdHighScore(int highScore)
    {
        flappyBirdHighScore = highScore;
    }

    //Get FlappyBird High Score
    public int GetFlappyBirdHIghScore()
    {
        return flappyBirdHighScore;
    }
}
