using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /*
    global variables. 
    Public means that they will be visible in the egine.
    Private means they will not be visible in the engine.
    */
    public float speed;
    public float jump;
    public bool isJumping;
    private float Move; //Is a float variable that can either be in the range of -1 to 1 with the given code later on
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets the component, specifically the Rigidbody2D component, that has been attached to the gameObject. A component must be attached for this to work.
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal"); //Have assigned the input class with the GetAxis method to measure how far left or right the player has chosen to move based on their inputs. Fully left is -1. No movement is 0. Fully right is 1. 

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        //rb.velocity gets the velocity component and assigns it with a new Vector2 object with the parameters of the x and y compoents of the velocity
        
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && (isJumping == false))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        Debug.Log("X value: " + rb.velocity.x + "Y value: " + rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = true;
        }
    }
}
