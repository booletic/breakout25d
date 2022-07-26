using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        // display level on scene load
        GetComponent<TextMeshProUGUI>().text = "Level " + gameManager.level;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
