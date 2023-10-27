using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSound;

    private bool levelCompleted = false;
    private void Start()
    {
        goalSound = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            goalSound.Play();
            //CompleteLevel();
            Invoke("CompleteLevel", 2f); // Has delay
            levelCompleted = true;

        }
    }

    private void CompleteLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


}
