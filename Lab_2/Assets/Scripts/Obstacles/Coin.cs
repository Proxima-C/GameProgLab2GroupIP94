using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.AddPoint();
            Destroy(gameObject);
        }
    }
}
