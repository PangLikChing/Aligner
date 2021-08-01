using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyBirdLevelManager : MonoBehaviour
{
    //change
    [SerializeField] Transform canvas;
    private const float COLLIDER_WIDTH = 100f;
    private const float COLLIDER_MOVESPEED = 200f;
    private const float PIPE_DESTROY_XPOSITION = -250f;
    private const float PIPE_SPAWN_XPOSITION = 2048f;

    List<Collider> colliderList;
    float spawnTimer, spawnInterval, timePassed;
    GameObject scoreText, gameoverPanel, jumppad, skills;
    bool intervalAdded = false, finalScoreUpdated;
    int score;
    FlappyBirdSpawningHoldLength flappyBirdSpawningHoldLength;
    GameManager gameManager;
    Player player;

    public bool isAlive = true;
    public float colliderMovespeed;

    void Awake()
    {
        //Initialize
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.GetComponent<Player>();

        scoreText = canvas.GetChild(2).gameObject;
        gameoverPanel = canvas.GetChild(4).gameObject;
        jumppad = canvas.GetChild(5).gameObject;
        skills = canvas.GetChild(6).gameObject;

        colliderMovespeed = 250f;

        colliderList = new List<Collider>();
        spawnInterval = 5f;
        flappyBirdSpawningHoldLength = GetComponent<FlappyBirdSpawningHoldLength>();

        finalScoreUpdated = false;
    }

    void Update()
    {
        //Game Over
        if(isAlive == false && finalScoreUpdated == false)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //Remove the score text on the screen
        scoreText.SetActive(false);
        //Update the score text on game over panel
        int currentScore = scoreUpdate();

        jumppad.SetActive(false);
        skills.SetActive(false);
        finalScoreUpdated = true;
        //Pop up the game over panel
        gameoverPanel.SetActive(true);
        //Save
        if (currentScore > player.GetFlappyBirdHIghScore())
        {
            player.SetFlappyBirdHighScore(currentScore);
            //Display the new symbol
            gameoverPanel.transform.GetChild(3).gameObject.SetActive(true);
        }
        player.SetPlayerExperience(player.GetPlayerExperience() + (currentScore / 10));

        gameManager.Save();

        //Display scores
        gameoverPanel.transform.GetChild(1).GetComponent<Text>().text = "Score: " + currentScore;
        gameoverPanel.transform.GetChild(2).GetComponent<Text>().text = "High Score: " + player.GetFlappyBirdHIghScore();
    }

    public void playAgain()
    {
        //Play Again
        //for testing
        SceneManager.LoadScene(2);
    }

    public int scoreUpdate()
    {
        //Calculate the time passed
        timePassed += Time.deltaTime / Time.timeScale;

        //Start giving score after 3 seconds
        score = Mathf.FloorToInt(timePassed - 3);

        if (score <= 0)
        {
            scoreText.GetComponent<Text>().text = "Score: 0";
            return 0;
        }
        else
        {
            scoreText.GetComponent<Text>().text = "Score: " + score;
            if (score / 10 > 0 && score % 10 == 0 && intervalAdded == false)
            {
                spawnInterval -= 0.2f;
                intervalAdded = true;
            }
            else if (score / 10 > 0 && score % 10 != 0 && intervalAdded == true)
            {
                intervalAdded = false;
            }
            return score;
        }
    }

    public void spawnCollider(float height, float gapSize)
    {
        spawnTimer -= Time.deltaTime;
        //If the spawn timer reaches 0 or below
        if (spawnTimer <= 0)
        {
            //spawn collider
            spawnTimer += spawnInterval;
            CreateGap(height, gapSize, PIPE_SPAWN_XPOSITION);
            flappyBirdSpawningHoldLength.skillColliderLength = height;
        }
    }

    public void moveColliders()
    {
        for (int i = 0; i < colliderList.Count; i++)
        {
            Collider collider = colliderList[i];
            collider.Move(colliderMovespeed);
            
            if (collider.GetXPosition() < PIPE_DESTROY_XPOSITION)
            {
                //Destory
                collider.DestorySelf();
                colliderList.Remove(collider);
                i--;
            }
        }
    }

    void CreateGap(float bottomPipeHeight, float gapSize, float positionX)
    {
        CreateCollider(bottomPipeHeight - gapSize / 2, positionX, true);
        CreateCollider(canvas.GetComponent<RectTransform>().sizeDelta.y - bottomPipeHeight - gapSize / 2, positionX, false);
    }

    void CreateCollider(float height, float positionX, bool bottom)
    {
        //position of created collider
        Transform newCollider = Instantiate(FlappyBirdGameAssets.GetInstance().collider, canvas.GetChild(1));
        if (bottom)
        {
            newCollider.position = new Vector3(positionX, 0f);
        }
        else
        {
            newCollider.position = new Vector3(positionX, canvas.GetComponent<RectTransform>().sizeDelta.y);
            newCollider.localScale = new Vector3(1, -1, 1);
        }

        //height of created collider
        RectTransform rectTransform = newCollider.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(COLLIDER_WIDTH, height);

        //Matching the box collider with the created collider
        BoxCollider2D boxCollider2D = newCollider.GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(COLLIDER_WIDTH, height);
        boxCollider2D.offset = new Vector2(0, height / 2);

        Collider collider = new Collider(newCollider);
        colliderList.Add(collider);
    }

    private class Collider
    {
        Transform colliderTransform;

        public Collider(Transform colliderTransform)
        {
            this.colliderTransform = colliderTransform;
        }

        public void Move(float colliderMovespeed)
        {
            colliderTransform.position += new Vector3(-1, 0, 0) * colliderMovespeed * Time.deltaTime;
        }

        public float GetXPosition()
        {
            return colliderTransform.position.x;
        }

        public void DestorySelf()
        {
            Destroy(colliderTransform.gameObject);
        }
    }
}
