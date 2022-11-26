using System.Collections;
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
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        score = 0;
        points = 5;
        maxLevel = 50;
        animator.SetTrigger("In");
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
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                foreach (Transform child in GameObject.Find("Enemy Parent").transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        // quit game when pressing escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {        
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }

        // return to menu if in end scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "EndScene")
            {
                LoadMenu();
            }

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
        StartCoroutine(Fade("EndScene"));
    }

    public void GameStart(int speed, int score)
    {
        // load play scene
        isGameActive = false;
        this.speed = speed;
        this.score = score;
        StartCoroutine(Fade("GameScene"));
    }

    public void LoadMenu()
    {
        // load menu scene
        StartCoroutine(Fade("MenuScene"));
    }

    public void UpdateScore()
    {
        // calculate score and update it to screen
        score += points * speed;
        GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>().text = "Score " + score;
    }

    IEnumerator Fade(string scene)
    {
        // fade-in and fade-out
        animator.SetTrigger("Out");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
        animator.SetTrigger("In");
    }
}
