using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 zRotation;

    public GameObject pauseHud;
    public GameObject soundManager;

    bool reverse;
    bool isPaused;

    private void Start()
    {
        Time.timeScale = 0;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                soundManager.GetComponent<AudioSource>().Play();
                pauseHud.SetActive(false);
                GameManager.instance.ResumeGame();
                isPaused = false;
            }
            else
            {
                soundManager.GetComponent<AudioSource>().Pause();
                pauseHud.SetActive(true);
                GameManager.instance.PauseGame();
                isPaused = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (reverse)
            {
                reverse = false;
            }
            else
            {
                reverse = true;
            }
        }

        if (reverse)
        {
            zRotation = new Vector3(0, 0, 2);
        }
        else
        {
            zRotation = new Vector3(0, 0, -2);
        }


        transform.RotateAround(target.position, zRotation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.CompareTag("Spinner"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                target = collider.transform;
                collider.GetComponent<AudioSource>().Play();
            }
        }

        if (collider.CompareTag("Enemy"))
        {
            soundManager.GetComponent<AudioSource>().Pause();
            collider.GetComponent<AudioSource>().Play();
            GameManager.instance.Death();
        }

        if (collider.CompareTag("Key"))
        {
            collider.GetComponent<AudioSource>().Play();
            Destroy(collider.gameObject, 0.5f);
        }

        if (collider.CompareTag("Flag"))
        {
            soundManager.GetComponent<AudioSource>().Pause();
            if (GameManager.instance.timeElapsed < GameManager.instance.bestTime)
            {
                GameManager.instance.bestTime = GameManager.instance.timeElapsed;
            }
            else if(GameManager.instance.bestTime <= 1.0f)
            {
                GameManager.instance.bestTime = GameManager.instance.timeElapsed;
            }

            GameManager.instance.LevelComplete();
        }
    }
}
