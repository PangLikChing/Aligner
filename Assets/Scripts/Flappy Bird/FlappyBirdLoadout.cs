using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FlappyBirdLoadout : MonoBehaviour
{
    string skillSelected;
    public int[] skillsList;
    [SerializeField] GameObject skills, loadoutInterface, gameInterface, levelManager;
    [SerializeField] Button button1;

    [SerializeField] FlappyBirdSpawningNormal flappyBirdSpawningNormal;
    [SerializeField] FlappyBirdSpawningHoldLength flappyBirdSpawningHoldLength;
    [SerializeField] FlappyBirdShield flappyBirdShield;
    [SerializeField] FlappyBirdSlow flappyBirdSlow;

    void Awake()
    {
        //Initialize
        skills = gameObject;
        skillsList = new int[skills.transform.childCount];

        for (int i = 0; i < skills.transform.childCount; i++)
        {
            skillsList[i] = 0;
        }
    }

    public void ConfirmLoadout()
    {
        for (int i = 0; i < skills.transform.childCount; i++)
        {
            if(skillsList[i] == 1)
            {
                skillSelected = transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text;
                FlappyBirdSkillCooldown skillCooldown = button1.GetComponent<FlappyBirdSkillCooldown>();
                //this is buggy
                if (i == 0)
                {
                    button1.onClick.AddListener(Hold);
                    button1.transform.GetChild(1).GetComponent<Text>().text = skillSelected;
                    //Cooldown of skill Hold
                    skillCooldown.skillCooldown = 20f;
                    
                }
                if (i == 1)
                {
                    button1.onClick.AddListener(Shield);
                    button1.transform.GetChild(1).GetComponent<Text>().text = skillSelected;
                    //Cooldown of skill Shield
                    skillCooldown.skillCooldown = 30f;
                }
                if (i == 2)
                {
                    button1.onClick.AddListener(Slow);
                    button1.transform.GetChild(1).GetComponent<Text>().text = skillSelected;
                    //Cooldown of skill Slow
                    skillCooldown.skillCooldown = 15f;
                }
                loadoutInterface.SetActive(false);
                gameInterface.SetActive(true);
                levelManager.SetActive(true);
            }
        }
    }

    void Hold()
    {
        //Skill 1
        //take the skill level of player
        flappyBirdSpawningHoldLength.skilltime = 7f;

        flappyBirdSpawningNormal.enabled = false;
        flappyBirdSpawningHoldLength.enabled = true;
    }

    void Shield()
    {
        flappyBirdShield.skilltime = 3f;

        flappyBirdShield.enabled = true;
    }

    void Slow()
    {
        flappyBirdSlow.skilltime = 5f;

        flappyBirdSlow.enabled = true;
    }
}
