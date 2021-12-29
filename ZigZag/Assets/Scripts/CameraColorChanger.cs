using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public Color[] colors;
    public Color targetColor;

    void Start() 
    {
        StartCoroutine(ColorChanger());
    }

    void Update() 
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, targetColor, Time.deltaTime);
    }

    IEnumerator ColorChanger()
    {
        while(true)
        {
            int randomColor = Random.Range(0,colors.Length);
            targetColor = colors[randomColor];
            yield return new WaitForSeconds(5f);
        }
    }
}
