
using UnityEngine;
using System.Collections;
 
public class DirectionMovement8 : MonoBehaviour
{
    Animator anim;
    public float speed = 5f;
    private Vector2 movement;
    float counter;

    string passtrigger = "";

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        counter = 0f;
        //GetComponent<Rigidbody2D>().velocity = movement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");




        movement = new Vector2(inputX, inputY);


        anim.SetFloat("X", inputX);
        anim.SetFloat("Y", inputY);
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            
            if (movement.y == 1 && movement.x == -1)
            {
                
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_up_left");
                passtrigger = "move_up_left";
                counter = .1f;
            }

            if (movement.y == 1 && movement.x == 1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_up_right");
                passtrigger = "move_up_right";
                counter = .1f;
            }

            if (movement.y == -1 && movement.x == -1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_down_left");
                passtrigger = "move_down_left";
                counter = .1f;
            }

            if (movement.y == -1 && movement.x == 1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_down_right");
                passtrigger = "move_down_right";
                counter = .1f;
            }

        }

        else if (counter <= 0)
        {
            if (movement.x == -1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_left");
                passtrigger = "move_left";
            }

            if (movement.x == 1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_right");
                passtrigger = "move_right";
            }


            if (movement.y == 1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_up");
                passtrigger = "move_up";
            }


            if (movement.y == -1)
            {
                anim.ResetTrigger(passtrigger);
                anim.SetTrigger("move_down");
                passtrigger = "move_down";
            }

            counter = 0;
        }

        counter -= Time.deltaTime;
        //Debug.Log(counter);

        transform.Translate(movement * speed * Time.deltaTime);

    }
}