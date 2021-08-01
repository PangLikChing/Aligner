using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdSelectSkills : MonoBehaviour
{
    GameObject skills;
    FlappyBirdLoadout flappyBirdLoadout;

    void Awake()
    {
        skills = transform.parent.gameObject;
        flappyBirdLoadout = skills.GetComponent<FlappyBirdLoadout>();
    }

    public void SelectSkill()
    {
        //Check
        if (transform.GetChild(1).gameObject.activeSelf == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            //Identify the skill
            for (int i = 0; i < skills.transform.childCount; i++)
            {
                if (skills.transform.GetChild(i).gameObject == gameObject)
                {
                    flappyBirdLoadout.skillsList[i] = 1;
                }
                else
                {
                    //Set the check mark on the other skills to inactive
                    skills.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    //Unselect the skill
                    flappyBirdLoadout.skillsList[i] = 0;
                }
            }
        }
        else
        {
            //Uncheck
            transform.GetChild(1).gameObject.SetActive(false);
            //Identify the skill
            for (int i = 0; i < skills.transform.childCount; i++)
            {
                if (skills.transform.GetChild(i).gameObject == gameObject)
                {
                    flappyBirdLoadout.skillsList[i] = 0;
                }
            }
        }
    }
}
