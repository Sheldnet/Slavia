using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouchButton : MonoBehaviour
{
    private float lastClickTime;
    public float doubleClickPeriod = 0.2f;
    public int buttonIndex;

    [SerializeField] private MainMenu mainMenuScript;
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject options;

    private void OnMouseButton()
    {
        if (Time.time - lastClickTime < doubleClickPeriod)
        {
            switch (buttonIndex)
            {
                case 1:
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    }
                case 2:
                    {
                        options.SetActive(true);
                        mainMenuObject.SetActive(false);
                        break;
                    }
                case 3:
                    {
                        Application.Quit();
                        break;
                    }
            }
        }
        else
        {
            switch (buttonIndex)
            {
                case 1:
                    {
                        mainMenuScript.redPouch();
                        break;
                    }
                case 2:
                    {
                        mainMenuScript.greenPouch();
                        break;
                    }
                case 3:
                    {
                        mainMenuScript.bluePouch();
                        break;
                    }
            }
        }
        lastClickTime = Time.time;
    }
}