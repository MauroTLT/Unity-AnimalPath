using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject player;

    void Start() {
        player = (player == null) ? GameObject.FindGameObjectWithTag("Player") : player;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            GameManager.lastCheckpoint = transform.position;
        }
    }
}
