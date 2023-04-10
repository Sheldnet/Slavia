using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouchDoubleClick : MonoBehaviour
{
    [SerializeField] GameObject mainMenuObject;
    [SerializeField] GameObject options;

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options() {
        options.SetActive(true);
        mainMenuObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
