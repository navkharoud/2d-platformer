using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [SerializeField] GameObject _shot;

    private float _speed = 5;
    private float _boundary = 3.5f;
    Rigidbody2D _rb;
    Animator _anim;
    Vector3 respawn = new Vector3 (0f, -2.8f, 0f);
   
    
    private bool _invincible = false;
   
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update() {
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            vel.x = -_speed;
        }
        else {
            vel.x = 0;
        }
        _rb.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.x > _boundary) {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary) {
            pos.x = -_boundary;
        }
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(_shot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //checks if we are in invicible mode or not 
        if (!_invincible) {

            if (other.tag == "AShot")
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                FindObjectOfType<UIManager>().ShipHit();
                Destroy(other.gameObject);
                _anim.SetTrigger("die");
                StartCoroutine(Invulnerable()); 

            }


        }
        
    }
    IEnumerator Invulnerable()  
    {
        _invincible = true; 
        yield return new WaitForSeconds(2);
        _invincible = false;
        Respawn();
        
    }

    void Respawn() {
        _anim.SetTrigger("respawn");
        transform.position = respawn;
    }

}
