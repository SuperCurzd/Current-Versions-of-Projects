using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Sprite _buttonDownSprite;
    [SerializeField] Sprite _buttonUpSprite;
    //Establish Terms
    Rigidbody2D _rigidbody2D;
    Vector2 _startPosition;

    void Awake()
    {
        //Call components before Start to save text later when using
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Labelling start position and locking the button to that position by default
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the button hits a wall, scene resets
        if (hasHitWall(collision)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    bool hasHitWall(Collision2D collision)
    {
        //Establishing what hitting a wall is
        if (collision.gameObject.name.Contains("Wall"))
            return true;

        return false;
    }
    void OnMouseDown()
    {
        //Changing the button to indicate it is being held down
        GetComponent<SpriteRenderer>().sprite = _buttonDownSprite;
    }

    void OnMouseUp()
    {
        //Changing the button to indicate it has been released
        GetComponent<SpriteRenderer>().sprite = _buttonUpSprite;
        SceneManager.LoadScene(0);
    }

    void OnMouseDrag()
    {
        //Talking coordinates of current mouse position for use with desired position function
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }


        // Update is called once per frame
        void Update()
    {
        
    }
}
