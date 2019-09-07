using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10;
    public float dropSpeed;
    public KeyCode actionKey;

    private float currentMoveSpeed; 

    private int playerNum;
    private float defaultY;

    private Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        defaultY = transform.position.y;

        playerNum = transform.name.Contains("1") ? 1 : 2;
        moveSpeed = (playerNum == 1) ? moveSpeed : -moveSpeed;

        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(currentMoveSpeed * Time.deltaTime, 0, 0));
        
        if(Input.GetKey(KeyCode.S) && !isDropping)
        {
            StartCoroutine(Dropping());
        }
    }

    private bool isDropping = false;
    IEnumerator Dropping()
    {
        isDropping = true;
        rb2d.gravityScale = 3;
        while(isDropping)
        {
            if (currentMoveSpeed > 0)
            {
                currentMoveSpeed *= 0.99f;
            }
            else
            {
                currentMoveSpeed = 0;
            }
            yield return null;
        }
        isDropping = false;
        //if (!isRising)
        //{
        //    StartCoroutine(Rising());
        //}
    }

    //private bool isRising = false;
    //IEnumerator Rising()
    //{
    //    isRising = true;
    //    rb2d.gravityScale = -3;
    //    while (transform.position.y < defaultY)
    //    {

    //        if (currentMoveSpeed < moveSpeed)
    //        {
    //            currentMoveSpeed *= 1.2f;
    //        }
    //        else
    //        {
    //            currentMoveSpeed = moveSpeed;
    //        }
    //        yield return null;
    //    }
    //    rb2d.velocity = Vector2.zero;
    //    rb2d.gravityScale = 0;
    //    transform.position = new Vector2(transform.position.x, defaultY);
    //    currentMoveSpeed = moveSpeed;

    //    isRising = false;
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Bouncepad")
        {
            isDropping = false;
        }
        else if (col.transform.tag == "OutOfBounds")
        {
            isDropping = false;
        }
    }
}
