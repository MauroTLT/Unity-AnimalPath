using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    private bool climbing = false;
    private void OnCollisionEnter(Collision collision) {
        climbing = true;
        StartCoroutine(DoClimb(collision.gameObject));
    }

    private void OnCollisionExit(Collision collision) {
        climbing = false;
    }
    IEnumerator DoClimb(GameObject player) {
        while (climbing) {
            player.transform.Translate(
                new Vector3(
                    0,
                    10,
                    0
                ) * Time.deltaTime, Space.World
            );
            yield return new WaitForSeconds(0.01f);
        }
    }
}
