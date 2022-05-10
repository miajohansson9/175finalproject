using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 7f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask lava;

    public GameOver GameOver;
    public int points;
    public Text score;
    public bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   

        // if game ended we dont want to do anything
        if (gameEnded) return;


        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, rb.velocity.z);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        if (TouchedLava())
        {
            gameEnded = true;
            GameOver.Setup(points);
        }
        else
        {
            points++;
            score.text = points.ToString();
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    bool TouchedLava()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, lava);
    }
}
