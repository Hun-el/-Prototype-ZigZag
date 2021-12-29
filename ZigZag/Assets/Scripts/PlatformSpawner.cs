using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop = false;
    bool activeSpawn;

    public PoolSystem pool;

    void Start() 
    {
        lastPosition = lastPlatform.position;

        pool = new PoolSystem(platform);
        pool.InstantiatePlatformPool(100);
    }

    void Update() 
    {
        if(GameManager.instance.gameOver)
        {
            stop = false;
        }

        if(GameManager.instance.gameStarted && !activeSpawn)
        {
            activeSpawn = true;
            StartCoroutine(SpawnPlatforms());
        }
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();
            GameObject platformInstance = pool.GetPlatformPool();
            platformInstance.GetComponent<Rigidbody>().isKinematic = true;
            platformInstance.transform.localRotation = Quaternion.identity;
            platformInstance.transform.localPosition = newPos;
            platformInstance.transform.localScale = new Vector3(0,0,0);
            platformInstance.transform.DOScale(new Vector3(2,1,2) , 1f).SetEase(Ease.OutExpo);
            platformInstance.gameObject.SetActive(true);

            lastPosition = newPos;
            yield return new WaitForSeconds(0.25f);
        }
    }

    void GeneratePosition()
    {
        newPos = lastPosition;
        int rand = Random.Range(0,2);

        if(rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
}
