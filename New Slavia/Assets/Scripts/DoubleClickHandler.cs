using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoubleClickHandler : MonoBehaviour
{
    [SerializeField] private float doubleClickTimeLimit = 0.3f;
    [SerializeField] private int buttonIndex;

    [SerializeField] private MainMenu mainMenuScript;
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject options;

    protected void Start()
    {
        StartCoroutine(InputListener());
    }

    private IEnumerator InputListener()
    {
        while (enabled)
        {
            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        yield return new WaitForEndOfFrame();

        float count = 0f;

        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;
            yield return null;
        }
        SingleClick();
    }

    private void SingleClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "PouchButton")
            {
                switch (hit.collider.gameObject.GetComponent<DoubleClickHandler>().buttonIndex)
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
        }
    }

    private void DoubleClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "PouchButton")
            {
                switch (hit.collider.gameObject.GetComponent<DoubleClickHandler>().buttonIndex)
                {
                    case 1:
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            break;
                        }
                    case 2:
                        {
                            options.SetActive(true);
                            //mainMenuObject.SetActive(false);
                            break;
                        }
                    case 3:
                        {
                            Application.Quit();
                            break;
                        }
                }
            }
        }
    }
}