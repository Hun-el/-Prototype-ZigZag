using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted,gameOver;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update() 
    {
        if(!gameStarted)
        {   
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    void GameStart()
    {
        gameStarted = true;
    }

    public void GameOver()
    {
        gameOver = true;
        LoadingSystem.instance.LoadLevel("Restart");
    }
}
