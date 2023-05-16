using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimBut : MonoBehaviour
{
    public GameObject rightStick;
    public GameObject spriteTurn;
    private PlayerInput _playerInput;
    private Shooting _shooting;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _shooting = GetComponentInParent<Shooting>();
        _playerInput.LookDirection = 0;
    }
    public void OnButtonPress()
    {
        if (_shooting.autoShoot == false)
        {
            _shooting.autoShoot = true;
            this.GetComponent<Collider2D>().enabled = true;
            spriteTurn.SetActive(true);
            rightStick.SetActive(false);
        }
        else
        {
            _shooting.autoShoot = false;
            this.GetComponent<Collider2D>().enabled = false;
            spriteTurn.SetActive(false);
            rightStick.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            _shooting.autoshoting = true;
            if (collider != null)
            {

                Vector2 targetDir = collider.transform.position - transform.position;
                float sign = (collider.transform.position.y < transform.position.y) ? -1.0f : 1.0f;

                float angleRotate = Vector2.Angle(Vector2.right, targetDir) * sign;

                _playerInput.LookDirection = angleRotate;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            _shooting.autoshoting = false;

        }
    }

}
