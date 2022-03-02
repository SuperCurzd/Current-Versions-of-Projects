using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] string _nextLevelName;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If it detects a collision, if the collision is determined to be the Player, it moves to the next level
        if (goalHasBeenReached(collision))
            GoToNextLevel();
    }

    private bool goalHasBeenReached(Collision2D collision)
    {
        //If the Collision was with the Player, then goal has been reached
        if (collision.gameObject.name == "Player")
            return true;

        return false;
    }
       
    void GoToNextLevel()
    {
        //Going to the next level as referenced by the Serialized Field
        Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

}
