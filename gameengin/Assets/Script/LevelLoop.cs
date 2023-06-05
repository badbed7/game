using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoop : MonoBehaviour
{

    public GameObject level;
    public int count = 3;
    public float SpawnTime = 5f;
    

    private GameObject[] platforms;
    private Vector3 poolPosition= new Vector3(0,0,-300);
    private int currentIndex = 0;

    void Start()
    {
        platforms= new GameObject[count];
        for( int i =0; i<count;i++)
            platforms[i]=Instantiate(level, poolPosition, transform.rotation);
    }

    private float lastTime=0f;

    void Update() 
    {
        if (Time.time >= lastTime + SpawnTime)
        {
            lastTime = Time.time;

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector3(0,0,81.5f);
            currentIndex++;
            if(currentIndex>=count) 
            {
                currentIndex = 0;
            }
        }
    }
}
