using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public int speed;
    public int score;
    public int points;
    public int maxLevel;
    public bool isGameActive;
    public GameManager EnemyParent;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        score = 0;
        points = 5;
        maxLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            // add level progression
            if (EnemyAlive() == 0)
            {
                level++;

                if (level > maxLevel)
                {
                    GameOver();
                }
                else
                {
                    GameStart(speed, score);
                }
            }
        }

        // for testing: destroy all enemies
        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (Transform child in GameObject.Find("Enemy Parent").transform)
            {
                Destroy(child.gameObject);
            }
        }

        // quit game when pressing escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit!");
            Application.Quit();
        }
    }

    int EnemyAlive()
    {
        // return child count of enemy parent
        return GameObject.Find("Enemy Parent").transform.childCount;
    }

    public void GameOver()
    {
        // reset level
        level = 1;

        // load game-over scene
        isGameActive = false;
        SceneManager.LoadScene("EndScene");
    }

    public void GameStart(int speed, int score)
    {
        // load play scene
        this.speed = speed;
        this.score = score;
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        // load menu scene
        SceneManager.LoadScene("MenuScene");
    }

    public void UpdateScore()
    {
        // calculate score and update it to screen
        score += points * speed;
        GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>().text = "Score " + score;
    }
}
