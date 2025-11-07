using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public static Menu ST { get; private set; }


    private void Awake()
    {
        ST = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
   public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
