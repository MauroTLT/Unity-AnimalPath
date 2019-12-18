using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public GameObject player;
    public GameObject levelCompleteCanvas, pauseButton;
    public GameObject firework;

    void Start() {
        player = (player == null) ? GameObject.FindGameObjectWithTag("Player") : player;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            StartCoroutine(FireWorks());
        }
    }

    IEnumerator FireWorks() {
        GameManager.gamePaused = true;
        pauseButton.SetActive(false);
        for (int i = 0; i < 10; i++) {
            Vector3 position = new Vector3(
                transform.position.x + Random.Range(-3, 3),
                transform.position.y + 3,
                transform.position.z + Random.Range(-3, 3));

            Destroy(Instantiate(firework, position, Quaternion.identity), 1.0f);
            yield return new WaitForSeconds(0.5F);
        }
        levelCompleteCanvas.SetActive(true);
    }
}
