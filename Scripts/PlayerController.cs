using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //adding the rigid body component to the script
    public Rigidbody2D theRB;
    //speed of the player moving
    public float moveSpeed;

    //create a reference to the animator
    public Animator myAnim;

    //instantiate
    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private bool frozen;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

            
        }
        else
        {
            if(instance != this)
            {
               
                Destroy(gameObject);
                
            }
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            theRB.velocity = Vector2.zero;
        }
        else
        {
            if (canMove)
            {
                //move the character based on the input from the keyboard
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
                
            }
            else
            {
                theRB.velocity = Vector2.zero;
            }
            //set the float values of moveX and moveY to the players velocity
            myAnim.SetFloat("moveX", theRB.velocity.x);
            myAnim.SetFloat("moveY", theRB.velocity.y);




            //last direction faced
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                if (canMove)
                {
                    myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                    myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                }
                
            }


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
                transform.position.z);
        }
        
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(0.5f, 0.5f, 0.5f);
        topRightLimit = topRight + new Vector3 (-0.5f, -0.5f, 0f);
    }
    public void StopMovement()
    {
        frozen = true;
        myAnim.gameObject.GetComponent<Animator>().enabled = false;
    }
    public void ResumeMovement()
    {
        frozen = false;
        myAnim.gameObject.GetComponent<Animator>().enabled = true;
    }

}
