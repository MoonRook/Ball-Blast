using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
    }

    //������������ ������.
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //�������� ������.
    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    //����� �� ����.
    public void ExitGame()
    {
        Application.Quit();
    }
}
