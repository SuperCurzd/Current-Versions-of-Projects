using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    
    bool _hadDied;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the monster has the "Should Die" tag he...uh dies
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }  
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        //Establishing what should kill the monster, in this case contact with the bird or anything coming from almost directly above.
        if (_hadDied)
            return false;

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }

    IEnumerator Die()
    {
        _hadDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}

