using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Extra Jump
    public int maxJumpValue;
    int maxjump;

    private void Start()
    {
        maxjump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);

        if (Input.GetMouseButtonDown(0) && maxjump > 0) 
        {
            maxjump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && maxjump == 0 && isGrounded) 
        {
            Jump();
        }

        if (isGrounded) 
        {
            maxjump = maxJumpValue;
        }
    }

    void Jump() 
    {
        rb.velocity = Vector2.zero;
        // Bu satýr, Rigidbody'nin (rb) x ve y yöndeki hýzýný sýfýrlar. Bu, Rigidbody'nin mevcut hareketini durdurur.
        rb.AddForce(new Vector2(0,JumpSpeed));
        // Bu satýr, Rigidbody'e (rb) yönünde bir kuvvet ekler. Kuvvet, x bileþeni olmayan (x yönde hiçbir kuvvet olmadýðý) ve y bileþeni JumpSpeed olan bir Vector2 kullanýlarak oluþturulur. 
    }
}
