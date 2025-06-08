using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            gameManager.CompleteLevel();
        }
    }
}
