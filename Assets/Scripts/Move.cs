using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float forceValue;
    public float jumpValue;
    private Rigidbody rigidbody;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.01F) {
            rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            audio.Play();
        }
        if (Input.touchCount == 1) {
            if (Input.touches[0].phase == TouchPhase.Began && Mathf.Abs(rigidbody.velocity.y) < 0.01F) {
                rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
                audio.Play();
            }
        }
    }

    void FixedUpdate() {
        rigidbody.AddForce(
            new Vector3(
                Input.GetAxis("Horizontal"), 
                0,
                Input.GetAxis("Vertical")
            ) * forceValue
        );
        rigidbody.AddForce(
            new Vector3(
                Input.acceleration.x,
                0,
                Input.acceleration.y
            ) * forceValue
        );
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            print("Colisión");
        }
    }

    void OnTriggerEnter(Collider other) {
        print("Cambio de Zona");
    }
}
