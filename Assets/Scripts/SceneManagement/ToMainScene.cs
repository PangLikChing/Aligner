using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    bool hasPlayedBefore;
    SaveLoad saveLoad;
    GameObject loginButton, firstTimePanel;

    void Awake()
    {
        //Initialize
        saveLoad = FindObjectOfType<GameManager>().gameObject.GetComponent<SaveLoad>();
        loginButton = gameObject;
        firstTimePanel = transform.parent.gameObject.transform.Find("First Time Panel Background").gameObject;
    }

    public void ToMain()
    {
        //Check if player has an account
        hasPlayedBefore = saveLoad.Load();

        //If have data stored, load main scene
        if (hasPlayedBefore == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            //Pop up first time panel
            firstTimePanel.SetActive(true);
            //Make the Login Button disappear
            loginButton.SetActive(false);
        }
    }
}
