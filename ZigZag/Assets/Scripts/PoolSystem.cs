using System.Collections.Generic;
using UnityEngine;
 
public class PoolSystem
{
    private GameObject prefab;
    private Stack<GameObject> objectPool = new Stack<GameObject>();
 
    public PoolSystem(GameObject prefab)
    {
        this.prefab = prefab;
    }
 
    public void InstantiatePlatformPool(int miktar)
    {
        for( int i = 0; i < miktar; i++ )
        {
            GameObject _object = Object.Instantiate( prefab );
            AddPool( _object );
        }
    }
 
    public GameObject GetPlatformPool()
    {
        if(objectPool.Count > 0 )
        {
            GameObject obje = objectPool.Pop();
            return obje;
        }
 
        return Object.Instantiate(prefab);
    }
 
    public void AddPool(GameObject _object)
    {
        _object.gameObject.SetActive(false);
        _object.transform.parent = null;
        objectPool.Push( _object );
    }
}

