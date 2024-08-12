using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 3f;
    public float jumpSpeed = 1f;
    bool facingRight = true;

    bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();

        if (playerRB.velocity.x < 0 && facingRight)
        {
            // Yüzü sağa bakıyor demektir, sola çevir
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            // Yüzü sola bakıyor demektir, sağa çevir
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Math.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        this.transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
        Physics2D.OverlapCircle(groundCheckPosition, groundCheckRadius, groundCheckLayer);
    }

}
