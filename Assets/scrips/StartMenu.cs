using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startButton;

    void Start()
    {
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // �������� 1 �� ������ ����� ������� ����� � Build Settings
    }
}
