using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolllevel_cube : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if(!Gamemanager.instance.isGameover)
        {
            transform.Translate(Vector3.back*speed*Time.deltaTime);
            Destroy(gameObject,10f);
        }
    }
}
