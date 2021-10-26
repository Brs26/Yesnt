using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public KeyCode attackKey;
   
    public Animator anim;

    private Vector2 moveDirection;
    public FloatValue currentHealth;

    void Start()
    {
        anim.SetFloat("AnimMoveX", 0);
        anim.SetFloat("AnimMoveY", -1);
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    private IEnumerator Attack()
    {
        anim.SetBool("Attacking", true);
       
        yield return null;
        anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.3f);
        
    }
     /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }
    
    void ProcessInputs()
    {
        if (Input.GetKey(attackKey))
        {
            StartCoroutine(Attack());
        }
        
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    
    void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        
    }
    
}
