using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelController : MonoBehaviour {

    public GameObject btnPause, menuPause;
    public Button up, down, left, right, upLeft, upRight, downLeft, downRight, jump;
    private void Start() {
        if (!GameManager.tiltControl) {
            EventTrigger triggerUp = up.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerDown = down.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerLeft = left.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerRight = right.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerUpRight = upRight.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerUpLeft = upLeft.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerDownRight = downRight.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerDownLeft = downLeft.gameObject.AddComponent<EventTrigger>();
            EventTrigger triggerJump = jump.gameObject.AddComponent<EventTrigger>();

            var pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            var pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => GameManager.movY = 1);
            pointerUp.callback.AddListener((b) => GameManager.movY = 0);
            triggerUp.triggers.Add(pointerDown);
            triggerUp.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => GameManager.movY = -1);
            pointerUp.callback.AddListener((b) => GameManager.movY = 0);
            triggerDown.triggers.Add(pointerDown);
            triggerDown.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => GameManager.movX = -1);
            pointerUp.callback.AddListener((b) => GameManager.movX = 0);
            triggerLeft.triggers.Add(pointerDown);
            triggerLeft.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => GameManager.movX = 1);
            pointerUp.callback.AddListener((b) => GameManager.movX = 0);
            triggerRight.triggers.Add(pointerDown);
            triggerRight.triggers.Add(pointerUp);

            /* MOVIMIENTOS DIAGONALES */
            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => { GameManager.movX = 1; GameManager.movY = 1; });
            pointerUp.callback.AddListener((b) => { GameManager.movX = 0; GameManager.movY = 0; });
            triggerUpRight.triggers.Add(pointerDown);
            triggerUpRight.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => { GameManager.movX = -1; GameManager.movY = 1; });
            pointerUp.callback.AddListener((b) => { GameManager.movX = 0; GameManager.movY = 0; });
            triggerUpLeft.triggers.Add(pointerDown);
            triggerUpLeft.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => { GameManager.movX = -1; GameManager.movY = -1; });
            pointerUp.callback.AddListener((b) => { GameManager.movX = 0; GameManager.movY = 0; });
            triggerDownLeft.triggers.Add(pointerDown);
            triggerDownLeft.triggers.Add(pointerUp);

            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => { GameManager.movX = 1; GameManager.movY = -1; });
            pointerUp.callback.AddListener((b) => { GameManager.movX = 0; GameManager.movY = 0; });
            triggerDownRight.triggers.Add(pointerDown);
            triggerDownRight.triggers.Add(pointerUp);

            /* SALTO */
            pointerDown = new EventTrigger.Entry(); pointerDown.eventID = EventTriggerType.PointerDown;
            pointerUp = new EventTrigger.Entry(); pointerUp.eventID = EventTriggerType.PointerUp;
            pointerDown.callback.AddListener((b) => GameManager.jumping = true);
            pointerUp.callback.AddListener((b) => GameManager.jumping = false);
            triggerJump.triggers.Add(pointerDown);
            triggerJump.triggers.Add(pointerUp);
        } else {
            GameObject.Find("DirectionButtons").SetActive(false);
        }
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void PauseGame(bool pause) {
        menuPause.SetActive(pause);
        GameManager.gamePaused = pause;
    }
}
