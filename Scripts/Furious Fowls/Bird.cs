using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;  //Sets the force of the Bird when it's launched.
    [SerializeField] float _maxDragDistance = 5; //Sets the maximum distance from the start point the bird can be dragged from.

    //Establishing terms
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriterenderer;

    void Awake()
    {
        //Calling key components before the start function runs
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
         //Labelling start position and locking the bird to that position by default
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        //Changing the bird colour as it's being dragged to indicate such
        _spriterenderer.color = Color.red;   
    }

    void OnMouseUp()
    {
        //When mouse is released, cache current position and then move in direction of the start position
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        //Remove locked bird and adding force to launch, also resets colour back to white
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);

        _spriterenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        //Talking coordinates of current mouse position for use with desired position function
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
       
        //Charting distance as the variable from the start position, if distance is greater than set max, blocks further movement.
        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //On bird colliding with anything, triggers delayed reset
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        //Resets Bird position and locked state after 3 seconds
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
