using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] string _GameOver;

    public float timeValue = 90;
    public Text timeText;

    
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            Debug.Log("Game Over");
            SceneManager.LoadScene(_GameOver);
        }

        float seconds = timeToDisplay;
        float milliseconds = timeToDisplay % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:000}", seconds, milliseconds);


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // here using scene.name to check which scene was loaded
            if (scene.name == "level2")
            {
                // Destroy the gameobject this script is attached to
                timeToDisplay += 5;

            }

        }
    }

    

    void GameOver()
    {
        
        Debug.Log("Game Over");
        SceneManager.LoadScene(_GameOver);
    }
}
