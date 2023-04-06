using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject dude, fire, pouches, options, mainButton;
    private float tempTime;
    private int pouchAnimIndex;
    private bool cyclePouches;

    public void Start()
    {
        tempTime = 0f;
        pouchAnimIndex = 1;
        cyclePouches = true;
        mainButton.SetActive(false);
        options.SetActive(false);
    }

    public void FixedUpdate()
    {
        tempTime += Time.fixedDeltaTime;

        if (tempTime > 3)
        {
            if (cyclePouches)
            {
                switch (pouchAnimIndex)
                {
                    case 1:
                        {
                            pouches.GetComponent<Animator>().SetInteger("bottleId", 1);
                            pouchAnimIndex = 2;
                            break;
                        }
                    case 2:
                        {
                            pouches.GetComponent<Animator>().SetInteger("bottleId", 2);
                            pouchAnimIndex = 3;
                            break;
                        }
                    case 3:
                        {
                            pouches.GetComponent<Animator>().SetInteger("bottleId", 3);
                            pouchAnimIndex = 1;
                            break;
                        }
                }
            }
            tempTime = 0f;
        }
    }

    public void PlayGame()
    {
        if (tempTime < 1) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuiteGame()
    {
        if (tempTime < 2) return;
        Debug.Log("Quite");
    }

    public void redPouch()
    {
        //if (tempTime < 2) return;
        //tempTime = 0;
        cyclePouches = false;
        pouches.GetComponent<Animator>().SetInteger("bottleId", 1);
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 1;
        dude.GetComponent<Animator>().SetTrigger("throwDust");
        Invoke("createRedFire", 1f);
        mainButton.SetActive(true);
    }

    public void bluePouch()
    {
        //if (tempTime < 2) return;
        //tempTime = 0;
        cyclePouches = false;
        pouches.GetComponent<Animator>().SetInteger("bottleId", 3);
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 1;
        dude.GetComponent<Animator>().SetTrigger("throwDust");
        Invoke("createBlueFire", 1f);
        mainButton.SetActive(true);
    }

    public void greenPouch()
    {
        //if (tempTime < 2) return;
        //tempTime = 0;
        cyclePouches = false;
        pouches.GetComponent<Animator>().SetInteger("bottleId", 2);
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 1;
        dude.GetComponent<Animator>().SetTrigger("throwDust");
        Invoke("createGreenFire", 1f);
        mainButton.SetActive(true);
    }

    public void MainButtonClick()
    {
        //if (tempTime < 2) return;
        //tempTime = 0;
        switch (pouches.GetComponent<Animator>().GetInteger("bottleId"))
        {
            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

            case 2:
                options.SetActive(true);
                gameObject.SetActive(false);
                break;

            case 3:
                print("Выход");
                Application.Quit();
                break;

            default:
                break;
        }
    }

    public void createBlueFire()
    {
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 3;
        //pouches.GetComponent<Animator>().SetInteger("bottleId", 3);
        fire.GetComponent<Animator>().SetInteger("fireColor", 2);
    }

    public void createRedFire()
    {
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 3;
        //pouches.GetComponent<Animator>().SetInteger("bottleId", 1);
        fire.GetComponent<Animator>().SetInteger("fireColor", 1);
    }

    public void createGreenFire()
    {
        pouches.GetComponent<SpriteRenderer>().sortingOrder = 3;
        //pouches.GetComponent<Animator>().SetInteger("bottleId", 2);
        fire.GetComponent<Animator>().SetInteger("fireColor", 3);
    }
}