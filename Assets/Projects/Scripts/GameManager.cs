using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _totalEnemies;
    [SerializeField] private Text _gameStatusText;
    [SerializeField] private GameObject _restartButton;

    public static GameManager s_instance;

    private int _enemiesKilled = 0;

    private void Awake()
    {
        if (s_instance == null)
            s_instance = this;
        else
            Destroy(gameObject);
    }

    public void EnemyKilled()
    {
        _enemiesKilled++;

        CheckGameStatus();
    }

    public void PlayerDied() => 
        ShowGameStatus("You Lose!");

    private void Victory() => 
        ShowGameStatus("You Win!");

    private void CheckGameStatus()
    {
        if (_enemiesKilled >= _totalEnemies)
            Victory();
    }

    private void ShowGameStatus(string text)
    {
        _restartButton.SetActive(true);
        _gameStatusText.text = text;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }
}