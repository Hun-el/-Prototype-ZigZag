using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    PlatformSpawner platformSpawner;

    void Awake() 
    {
        platformSpawner = FindObjectOfType<PlatformSpawner>();
    }

    void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Fall();
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.DOScale(new Vector3(0,0,0) , 1f);
        Invoke("Fall2",2f);
    }

    void Fall2()
    {
        platformSpawner.pool.AddPool(this.gameObject);
    }
}
