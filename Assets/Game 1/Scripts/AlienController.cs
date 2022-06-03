using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour{

    [SerializeField] GameObject _ashot;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Shot") {
            
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            StartCoroutine(Die());
            FindObjectOfType<UIManager>().AlienHit();
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        if (Mathf.FloorToInt(Random.value * 10000.0f) % 5000 == 0) {
            Instantiate(_ashot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
}
