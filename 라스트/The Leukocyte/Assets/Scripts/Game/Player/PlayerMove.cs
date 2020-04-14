using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * basic 2D character controller
 * use array keys / WASD to move object up/down/left/right
 */
public class PlayerMove : MonoBehaviour
{
    
    public GameObject player;

    public static bool isFirst =true;


    // ################################
    // #                              #
    // #  플레이어 움직임 제한부 시작 #
    // #                              #
    // ################################
    public Transform corner_min;
    public Transform corner_max;
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;
    // ################################
    // #                              #
    // #   플레이어 움직임 제한부 끝  #
    // #                              #
    // ################################

    public static bool facingRight = true;
    public Animator anim;

    // change speed
    public static float speed = 5;

    // cached reference to a physics RigidBody
    private Rigidbody2D rigidBody2D;

    //--------------------------
    // get reference tot the RigidBody 2D compoonent
    // that is in the parent GameObject to which an instance of this script has been added
    private void KeepWithinMinMaxRectangle()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        float clampedX = Mathf.Clamp(x, x_min, x_max);
        float clampedY = Mathf.Clamp(y, y_min, y_max);

        transform.position = new Vector3(clampedX, clampedY, z);

    }
    void Awake()
    {
        x_max = corner_max.position.x;
        x_min = corner_min.position.x;
        y_max = corner_max.position.y;
        y_min = corner_min.position.y;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    //---------------------------
    void FixedUpdate()
    {

        // read from movement keys
        // arrow keys / WASD
        // GetAxis returns values between -1.0...0...+1.0
        if (!pause.isPausing)
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");

            anim.SetFloat("xSpeed", Mathf.Abs(xMove));
            anim.SetFloat("yUpSpeed", yMove);
            anim.SetFloat("yDownSpeed", -yMove);
            // mutliple by speed factor
            float xSpeed = xMove * speed;
            float ySpeed = yMove * speed;

            // create (dx,dy) vector object
            Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

            // set the velocity of the Physicsl rigid body to this (x,y) vector
            rigidBody2D.velocity = newVelocity;

          
            if (xMove > 0 && !facingRight)
            {
                Flip();
                player_.player_right = true;
                player_.player_left = false;
            }               
            else if (xMove < 0 && facingRight)
            {
                Flip();
                player_.player_right = false;
                player_.player_left = true;
            }

        }
            KeepWithinMinMaxRectangle();
        
    } 
    

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}