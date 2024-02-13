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
        // Bu sat�r, Rigidbody'nin (rb) x ve y y�ndeki h�z�n� s�f�rlar. Bu, Rigidbody'nin mevcut hareketini durdurur.
        rb.AddForce(new Vector2(0,JumpSpeed));
        // Bu sat�r, Rigidbody'e (rb) y�n�nde bir kuvvet ekler. Kuvvet, x bile�eni olmayan (x y�nde hi�bir kuvvet olmad���) ve y bile�eni JumpSpeed olan bir Vector2 kullan�larak olu�turulur. 
    }
}
