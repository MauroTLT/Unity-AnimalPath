using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class IndexController : MonoBehaviour {

    public GameObject mainMenu, levelsMenu;
    public AudioSource audio;
    private void Start() {
        GameObject.Find("BtnSettings").GetComponentInChildren<Text>().text = (GameManager.tiltControl) ? "Tilt Controls" : "Button Controls";
    }
    public void ChangeScene(string scene) {
        audio.Play();
        SceneManager.LoadScene(scene);
    }

    public void ChangeSubMenu(GameObject direction) {
        audio.Play();
        if (direction.Equals(mainMenu)) {
            levelsMenu.SetActive(false);
        } else {
            mainMenu.SetActive(false);
        }
        direction.SetActive(true);
    }

    public void ChangeControlSqueme() {
        audio.Play();
        GameManager.tiltControl = !GameManager.tiltControl;
        GameObject.Find("BtnSettings").GetComponentInChildren<Text>().text = (GameManager.tiltControl)? "Tilt Controls" : "Button Controls";
    }

    public void ExitGame() {
        audio.Play();
        Application.Quit();
    }
}
