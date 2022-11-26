using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManger =
            GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);

    }

    void SetDifficulty()
    {
        // params: projectile speed, initial score
        gameManger.GameStart(difficulty, 0);
    }

}
