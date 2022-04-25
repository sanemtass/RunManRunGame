using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    private Animator _anim;
    [SerializeField] private float speed;
    float x, z;
    public float jumpForce = 5;
    public bool isOnGround = true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * z);
        transform.Translate(Vector3.right * Time.deltaTime * speed * x);

        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _anim.SetBool("jump", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _anim.SetBool("jump", false);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }
    }

    
    

}
