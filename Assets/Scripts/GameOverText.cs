using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        // append game-over text with final score
        GetComponent<TextMeshProUGUI>().text = "Game Over, Score " + gameManager.score;
    }
}
