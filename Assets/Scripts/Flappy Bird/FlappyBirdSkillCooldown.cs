using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdSkillCooldown : MonoBehaviour
{
    public float skillCooldown;

    float currentSkillCooldown;

    Button skillButton;
    [SerializeField] Slider slider;
    [SerializeField] GameObject skillImage, cooldownText;

    void Awake()
    {
        skillButton = gameObject.GetComponent<Button>();
        slider.value = 1f;
    }

    void FixedUpdate()
    {
        if (isOnCooldown())
        {
            currentSkillCooldown -= Time.deltaTime;
            //Cooldown Overlay
            slider.value = 1 - (currentSkillCooldown / skillCooldown);
            cooldownText.GetComponent<Text>().text = Mathf.RoundToInt(currentSkillCooldown).ToString();
        }
        else
        {
            skillButton.interactable = true;
            cooldownText.SetActive(false);
            //For testing only
            skillImage.SetActive(true);
        }
    }

    public void skillUse()
    {
        //Start cooldown
        currentSkillCooldown = skillCooldown;
        skillButton.interactable = false;
        slider.value = 0f;
        cooldownText.SetActive(true);
        //For testing only
        skillImage.SetActive(false);
    }

    bool isOnCooldown()
    {
        if (currentSkillCooldown > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
