using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelMenu;

    public void PauseOn()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseOff()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void MainMenuOn()
    {
        panelMenu.SetActive(true);
    }

    public void MainMenuOff()
    {
        panelMenu.SetActive(false);
    }
    public void WinOn() 
    {
        panelWin.SetActive(true);
    }

    public void WinOff()
    {
        panelWin.SetActive(false);
    }
    public void Lose()
    {
        panelLose.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
//Camera.main.GetComponent<UIManager>().Win();
