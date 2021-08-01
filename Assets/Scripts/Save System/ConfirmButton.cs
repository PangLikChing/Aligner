using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    GameManager gameManager;
    Player player;
    SaveLoad saveLoad;
    [SerializeField] ToMainScene toMainScene;

    [SerializeField] Text PlayerNameInput;

    public string playerName;

    void Awake()
    {
        //Initialize
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.GetComponent<Player>();
        saveLoad = gameManager.GetComponent<SaveLoad>();
    }

    public void InitializePlayer()
    {
        //Get player input on Player Name
        playerName = PlayerNameInput.text.ToString();

        //Set Player Name
        player.playerName = playerName;

        //Set Player Level to 1
        player.SetLevel(1);

        //Set Player Experience to 0
        player.SetPlayerExperience(0);

        //Set Player HoldSkillLevel to 1
        player.SetPlayerHoldSkillLevel(1);

        //Set Player ShieldSkillLevel to 1
        player.SetPlayerShieldSkillLevel(1);

        //Set Player SlowSkillLevel to 1
        player.SetPlayerSlowSkillLevel(1);

        //Set Player Flappy Bird High Score
        player.SetFlappyBirdHighScore(0);

        //Save the new player profile
        saveLoad.Save();

        //Transition to main scene
        toMainScene.ToMain();
    }
}
