using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject gameoverText;
    public TMP_Text timeText;
    public TMP_Text recordText;
    GameObject socore;

    private float surviveTime;
    public bool isGameover;


    void Awake() {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        socore=GameObject.Find("HumanMale_Character_FREE");
        if (!isGameover)
        {
            surviveTime = socore.GetComponent<PlayerMove>().count;
            timeText.text = "Score : " + (int)surviveTime;   
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Score : " + (int)bestTime;

    }
}
