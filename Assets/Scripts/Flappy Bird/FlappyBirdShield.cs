using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdShield : MonoBehaviour
{
    CircleCollider2D circleCollider2D;

    GameObject shield;

    public float skilltime;

    void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        shield = transform.Find("Shield").gameObject;
    }

    void OnEnable()
    {
        circleCollider2D.enabled = false;
        shield.SetActive(true);
    }

    void Update()
    {
        if (skilltime > 0)
        {
            skilltime -= Time.deltaTime;
        }
        else if(skilltime <= 0)
        {
            circleCollider2D.enabled = true;
            shield.SetActive(false);
            this.enabled = false;
        }
    }
}
