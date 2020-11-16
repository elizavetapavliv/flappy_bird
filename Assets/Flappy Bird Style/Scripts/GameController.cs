using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;
    private int score = 0;
    public float scrollSpeed = -1.5f;

    public GameObject gameOverText;
    public Text scoreText;
    public static GameController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void BirdScored()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
