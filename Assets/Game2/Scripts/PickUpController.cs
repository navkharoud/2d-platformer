using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Invoke("SetFalse", 0.5f);
           
        }
    }
    private void SetFalse() {
        gameObject.SetActive(false);

    }

}
