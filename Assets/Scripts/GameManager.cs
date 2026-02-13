using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ST { get; private set; }

    public Dictionary<GameObject, Health> healthContainer;

    public int levelNum;

    private void Awake()
    {
        ST = this;
        healthContainer = new Dictionary<GameObject, Health>();


        if(SceneManager.GetActiveScene().name.Contains("-"))
            levelNum = int.Parse(SceneManager.GetActiveScene().name.Split("-")[1]);
    }

    public void LoadLevel(int num = -1)
    {
        if (num == -1)
        {
            if (SceneManager.GetSceneByName("Level-" + (levelNum + 1)).IsValid())
                SceneManager.LoadScene("Level-" + (levelNum+1));
            else
                SceneManager.LoadScene("Menu");
        }
        else if (num == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else if (num > 0)
        {
            if (SceneManager.GetSceneByName("Level-" + num).IsValid())
                SceneManager.LoadScene("Level-" + num);
            else
                SceneManager.LoadScene("Menu");
        }
    }
}
