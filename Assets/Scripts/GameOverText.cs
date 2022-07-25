using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        GetComponent<TextMeshProUGUI>().text = "Game Over, Score " + gameManager.score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
