using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
    public int count=0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("obstacle"))
        {
            count=count+1;
            Debug.Log(count);
        }
    }

}
