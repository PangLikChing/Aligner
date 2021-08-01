using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SaveLoad saveLoad;
    Player player;

    void Awake()
    {
        saveLoad = GetComponent<SaveLoad>();
        player = GetComponent<Player>();
    }

    void Start()
    {
        saveLoad.Load();
    }

    public void Save()
    {
        saveLoad.Save();
    }
}
