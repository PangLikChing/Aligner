using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdSlow : MonoBehaviour
{
    float slowedRatio;
    FlappyBirdLevelManager flappyBirdLevelManager;

    public float skilltime;

    void Awake()
    {
        flappyBirdLevelManager = GetComponent<FlappyBirdLevelManager>();
    }

    void OnEnable()
    {
        //Get player skill level
        slowedRatio = 0.5f;
        Time.timeScale = slowedRatio;
    }

    void Update()
    {
        if (skilltime > 0)
        {
            skilltime -= Time.deltaTime / Time.timeScale;
        }
        else if(skilltime <= 0)
        {
            Time.timeScale = 1;
            this.enabled = false;
        }
    }
}
