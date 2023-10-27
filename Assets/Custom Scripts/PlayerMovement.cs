using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private float moveSpeed = 7f; // Using SerializeField allows to change these values in the Unity GUI without having to change to public
    [SerializeField] private float jumpSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;
    private enum AnimationState {idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSound;
    private void Start()
    {
        Debug.Log("Testing start debug message!");
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // using GetAxisRaw instead of GetAxis makes it so you don't slide

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        AnimationState state;

        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            state = AnimationState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            //anim.SetBool("running", true);
            state = AnimationState.running;
            sprite.flipX = true;
        }
        else
        {
            //anim.SetBool("running", false);
            state = AnimationState.idle;

        }

        if (rb.velocity.y > .1f) 
        {
            state = AnimationState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = AnimationState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
       
    }
}
