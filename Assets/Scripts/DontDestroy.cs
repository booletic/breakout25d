using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // a singleton to keep game-manager alive between scenes
        GameObject[] gameManage = GameObject.FindGameObjectsWithTag("GameManager");
        //GameObject[] eventSys = GameObject.FindGameObjectsWithTag("EventSystem");
        GameObject[] fade = GameObject.FindGameObjectsWithTag("Fade");

        if (gameManage.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //if (eventSys.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        if (fade.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
