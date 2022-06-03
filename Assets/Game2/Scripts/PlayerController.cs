using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 4.5f;
    [SerializeField] private float _jumpForce = 15.0f;
    Animator _anim;
    private bool _isGrounded;
    Rigidbody2D _rb;
    private Vector3 _respawn = new Vector3(-3.5f, -1, 1);
    private bool _reachedCheckpoint = false;

    public bool reachedCheckpoint { 
        get { return _reachedCheckpoint; }
        set { _reachedCheckpoint = value; }

    }
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
        _rb.velocity = movement;
        

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            

        }
        

        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            
        }
        

        if (collision.gameObject.tag == "Enemy")
        {
            //kills enemy if our plays falls on top
            if (_rb.velocity.y<0) {
                Destroy(collision.gameObject);
            }
            else {
                Destroy(gameObject);
            }
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
    private void Respawn() {
        transform.position = _respawn;
    
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lowerwall") {
            Invoke("Respawn", 0.5f);
        }
        //checkpoint reached
        if (collision.gameObject.tag == "Tree")
        {
            _reachedCheckpoint = true;
            _respawn = new Vector3(44.0f, 1.0f, 1.0f);
            
        }
        if (collision.gameObject.tag == "House")
        {
            Debug.Log("YOU HAVE FINISHED THE LEVEL");

        }
    }

}
