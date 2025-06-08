using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        if (!hasGameEnded)
        {
            hasGameEnded = true;
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.enabled = false;
                    completeLevelUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("Error, script de movimiento de jugador inexistente");
                }
            }
            else
            {
                Debug.LogError("Error, jugador no encontrado");
            }
        }
    }

    public float restartDelay = 1f;
    public void EndGame()
    {
        if (!hasGameEnded)
        {
            hasGameEnded = true;
            Debug.Log("GameOver");
            Invoke("Restart", restartDelay);
        }
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
