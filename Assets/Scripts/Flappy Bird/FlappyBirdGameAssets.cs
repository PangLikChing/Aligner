using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGameAssets : MonoBehaviour
{
    private static FlappyBirdGameAssets instance;

    public static FlappyBirdGameAssets GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

    public Transform collider;
}
