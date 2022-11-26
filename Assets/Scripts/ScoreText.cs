using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        // force to refresh score on scene load
        GetComponent<TextMeshProUGUI>().text = "Score " + gameManager.score;
    }
}
