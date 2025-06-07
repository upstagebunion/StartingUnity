using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public float startPosition;
    public float currentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = player.position.z - startPosition;
        scoreText.text = currentPosition.ToString("0");
    }
}
