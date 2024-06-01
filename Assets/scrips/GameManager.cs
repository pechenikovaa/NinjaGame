using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject player;
    private float screenHeight;
    private float lastJumpYPosition;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found! Please ensure the player object has the 'Player' tag.");
        }
        else
        {
            // Получаем высоту экрана в мировых координатах
            screenHeight = Camera.main.orthographicSize * 2f;
            lastJumpYPosition = player.transform.position.y;
        }
    }

    void Update()
    {
        if (!isGameOver && player != null)
        {
            if (player.transform.position.y < lastJumpYPosition - screenHeight)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over! Loading StartScene...");
        SceneManager.LoadScene("GameOverImage");
    }
}
