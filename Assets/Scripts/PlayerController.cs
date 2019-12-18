using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 6;
    public float jumpForce = 100;
    public bool forceMovement = false;
    private bool inGround = true;
    private Animator anim;
    private Rigidbody rb;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground" && inGround == false) {
            inGround = true;
        }
    }

    void Update() {
        if (!GameManager.gamePaused) {
            ControllPlayer();
        }
    }

    void LateUpdate() {
        if (transform.position.y < -30) {
            RespawnPlayer();
        }
    }

    public static void RespawnPlayer() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GameManager.lastCheckpoint;
        GameManager.deaths++;
    }

    void ControllPlayer() {
        float moveHorizontal = 0;
        float moveVertical = 0;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        moveHorizontal = (moveHorizontal == 0) ? ((GameManager.tiltControl)? Input.acceleration.x : GameManager.movX) : moveHorizontal;
        moveVertical = (moveVertical == 0) ? ((GameManager.tiltControl) ? Input.acceleration.y : GameManager.movY) : moveVertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (forceMovement) {
            movement = new Vector3(moveHorizontal * 10, 0.0f, moveVertical * 10);
            rb.AddForce(movement, ForceMode.Impulse);
        } else {
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }

        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        } else {
            anim.SetInteger("Walk", 0);
        }

        // GetButtonDown debes pulsar cada vez / GetButton deja mantener pulsado
        if (Input.GetButtonDown("Jump") && inGround) {
            inGround = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
        
        if ((!GameManager.tiltControl && GameManager.jumping) || (GameManager.tiltControl && Input.touchCount == 1)) {
            if (inGround) {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                inGround = false;
                anim.SetTrigger("jump");
            }
        }
    }
}