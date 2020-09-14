using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour
{
    public string newSceneName = "new Scene Name here";
    
    public string goToPlaceName;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            SceneManager.LoadScene(newSceneName);
        }
    }
}
