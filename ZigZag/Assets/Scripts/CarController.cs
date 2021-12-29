using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;

    bool movingLeft = true;
    bool firstInput = true;

    void Update() 
    {
        if(GameManager.instance.gameStarted && !GameManager.instance.gameOver)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y < -1 && !GameManager.instance.gameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    void CheckInput()
    {
        if(firstInput){ firstInput = false; return; }

        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0,90,0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
