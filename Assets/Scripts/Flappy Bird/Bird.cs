using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    const float JUMP_POWER = 600f;
    Rigidbody2D rigidbody2D;
    [SerializeField] FlappyBirdLevelManager flappyBirdLevelManager;

    void Awake()
    {
        //Initialize
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        //Increase the y axis velocity to create a Jump effect
        rigidbody2D.velocity = Vector2.up * JUMP_POWER;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        //Game Over
        flappyBirdLevelManager.isAlive = false;
    }
}