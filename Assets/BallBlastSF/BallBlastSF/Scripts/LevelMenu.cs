using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu; //������ �� ������� UI ����.

    [SerializeField] private GameObject _levelMenu; //������ �� ������� UI ����.

    [SerializeField] private StoneSpawner _stoneSpawner;

    [SerializeField] private Bag _bag;

    [SerializeField] private Turret _turret;

    [SerializeField] private SceneHelper _sceneHelper;

    [SerializeField] private GameObject _progressPanel; //������ �� ������ ���������.

    [SerializeField] private GameObject _storePanel; //������ �� ������ ��������.

    //���������� ���� � �������� ���� �����.
    public void NextLevel()
    {
        _levelMenu.SetActive(false);

        Time.timeScale = 1f;

       // _stoneSpawner.CurrentLevel++;

        //_stoneSpawner.amountSpawned = 0;

       // PlayerPrefs.SetInt("LevelMenu:CurrentLevel", _stoneSpawner.CurrentLevel);

        PlayerPrefs.SetInt("LevelMenu:AmountCoin", _bag.GetAmountCoin());

        _sceneHelper.RestartLevel();
    }

    //��������� ������� ����.
    public void MainMenu()
    {
        _levelMenu.SetActive(false);

        _mainMenu.SetActive(true);

        _progressPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    //��������� ���� ��������.
    public void StoreMenu()
    {
        _levelMenu.SetActive(false);

        _storePanel.SetActive(true);

        Time.timeScale = 1f;
    }
}
