using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdSpawningNormal : MonoBehaviour
{
    [SerializeField] Transform canvas;
    FlappyBirdLevelManager flappyBirdLevelManager;
    FlappyBirdSpawningHoldLength flappyBirdSpawningHoldLength;

    GameObject scoreText, gameoverPanel;

    float length, minLength, maxLength, gapSize, offset;

    void Awake()
    {
        //Initialize
        scoreText = canvas.GetChild(2).gameObject;
        gameoverPanel = canvas.GetChild(4).gameObject;

        //offset makes the collider looks good at all random heights
        offset = 50f;
        gapSize = 500f;
        //Minimum length of the upper collider
        minLength = gapSize / 2 + offset;
        //Maximum length of the upper coliider
        maxLength = canvas.GetComponent<RectTransform>().sizeDelta.y - gapSize / 2 - offset;

        flappyBirdLevelManager = gameObject.GetComponent<FlappyBirdLevelManager>();
        flappyBirdSpawningHoldLength = gameObject.GetComponent<FlappyBirdSpawningHoldLength>();
    }

    void Update()
    {
        if (flappyBirdLevelManager.isAlive)
        {
            flappyBirdLevelManager.moveColliders();

            length = Random.Range(minLength, maxLength);

            flappyBirdLevelManager.spawnCollider(length, gapSize);

            flappyBirdLevelManager.scoreUpdate();
        }
    }
}
