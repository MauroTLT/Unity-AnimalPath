using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

    public GameObject player;
    public float moveX = 0;
    public float moveY = 0;
    public float moveZ = 0;
    public float speed = 2;

    private Vector3 originalPosition;

    private void Start() {
        player = (player == null) ? GameObject.FindGameObjectWithTag("Player") : player;
        originalPosition = transform.position;
        if (moveX != 0) {
            StartCoroutine(MoveX());
        }
        if (moveY != 0) {
            StartCoroutine(MoveY());
        }
        if (moveZ != 0) {
            StartCoroutine(MoveZ());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            PlayerController.RespawnPlayer();
        }
    }

    IEnumerator MoveX() {
        bool flag = (moveX > 0);
        while (true) {
            if (!GameManager.gamePaused) {
                Vector3 movement = Vector3.zero;
                if ((transform.position.x < ((moveX > 0) ? (originalPosition.x + moveX) : (originalPosition.x - moveX))) && flag) {
                    movement = new Vector3(speed, 0, 0);
                } else {
                    flag = false;
                }
                if ((transform.position.x > ((moveX > 0) ? (originalPosition.x - moveX) : (originalPosition.x + moveX))) && !flag) {
                    movement = new Vector3(-speed, 0, 0);
                } else {
                    flag = true;
                }
                transform.Translate(movement * speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.01F);
        }
    }

    IEnumerator MoveY() {
        bool flag = (moveY > 0);
        while (true) {
            if (!GameManager.gamePaused) {
                Vector3 movement = Vector3.zero;
                if ((transform.position.y < ((moveY > 0) ? (originalPosition.y + moveY) : (originalPosition.y - moveY))) && flag) {
                    movement = new Vector3(0, speed, 0);
                } else {
                    flag = false;
                }
                if ((transform.position.y > ((moveY > 0) ? (originalPosition.y - moveY) : (originalPosition.y + moveY))) && !flag) {
                    movement = new Vector3(0, -speed, 0);
                } else {
                    flag = true;
                }
                transform.Translate(movement * speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.01F);
        }
    }

    IEnumerator MoveZ() {
        bool flag = (moveZ > 0);
        while (true) {
            if (!GameManager.gamePaused) {
                Vector3 movement = Vector3.zero;
                if ((transform.position.z < ((moveZ > 0) ? (originalPosition.z + moveZ) : (originalPosition.z - moveZ))) && flag) {
                    movement = new Vector3(0, 0, speed);
                } else {
                    flag = false;
                }
                if ((transform.position.z > ((moveZ > 0) ? (originalPosition.z - moveZ) : (originalPosition.z + moveZ))) && !flag) {
                    movement = new Vector3(0, 0, -speed);
                } else {
                    flag = true;
                }
                transform.Translate(movement * speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.01F);
        }
    }

}
