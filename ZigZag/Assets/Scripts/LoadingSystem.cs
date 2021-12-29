﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingSystem : MonoBehaviour
{
    public static LoadingSystem instance;

    void Awake() 
    {
        instance = this;
    }

    void Start() 
    {
        Image i = transform.GetChild(0).GetComponent<Image>();
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1f);
        transform.GetChild(0).GetComponent<Image>().DOFade(0,0.75f);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelCo(levelName));
    }

    IEnumerator LoadLevelCo(string levelName)
    {
        if(levelName == "Restart")
        {
            levelName = SceneManager.GetActiveScene().name;
            transform.GetChild(0).GetComponent<Image>().DOFade(1,0.75f);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(levelName);
        }
        else
        {
            // animator.SetTrigger("End");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(levelName);
        }
    }
}
