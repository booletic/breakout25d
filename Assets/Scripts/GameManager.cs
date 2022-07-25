using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public bool isGameActive = false;
    public GameManager EnemyParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            // add level progression
            if (GameObject.Find("Enemy Parent").transform.childCount == 0)
            {
                level++;

                if (level >= 5)
                {
                    GameOver();
                } else
                {
                    GameStart(level);
                }
            }
        }
    }

    public void GameOver()
    {
        // load game-over scene
        isGameActive = false;
        SceneManager.LoadScene("EndScene");
    }

    public void GameStart(int difficulty)
    {
        // load play scene 
        level = difficulty;
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        // load menu scene
        SceneManager.LoadScene("MenuScene");
    }
}
