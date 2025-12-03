using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _totalCoins = 9;
    [SerializeField] private float _levelTime = 40f;

    private int _collectedCoins = 0;
    private float _currentTime;
    private bool _gameEnded = false;
    private int _lastSecond = -1;

    private void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        if (_gameEnded)
        {
            HandleRestart();
            return;
        }

        UpdateTimer();
        CheckGameEnd();
    }

    private void InitializeGame()
    {
        _currentTime = _levelTime;
        Debug.Log($"Соберите {_totalCoins} монет за {_levelTime} секунд!");
        UpdateUI();
    }

    private void UpdateTimer()
    {
        _currentTime -= Time.deltaTime;

        int currentSecond = Mathf.CeilToInt(_currentTime);
        if (currentSecond != _lastSecond && currentSecond >= 0)
        {
            UpdateUI();
            _lastSecond = currentSecond;
        }
    }

    private void CheckGameEnd()
    {
        if (_currentTime <= 0f)
        {
            EndGame(false);
        }
    }

    private void UpdateUI()
    {
        Debug.Log($"Время: {Mathf.CeilToInt(_currentTime)} сек | Монеты: {_collectedCoins}/{_totalCoins}");
    }

    public void CollectCoin()
    {
        if (_gameEnded) return;

        _collectedCoins++;
        UpdateUI();

        if (_collectedCoins >= _totalCoins)
        {
            EndGame(true);
        }
    }

    private void EndGame(bool isWin)
    {
        _currentTime = Mathf.Max(_currentTime, 0f);

        if (isWin)
        {
            Debug.Log($"ПОБЕДА! Все монеты собраны за {Mathf.CeilToInt(_levelTime - _currentTime)} секунд!");
        }
        else
        {
            Debug.Log("ПОРАЖЕНИЕ! Время вышло!");
        }

        _gameEnded = true;
        Debug.Log("ДЛЯ ПЕРЕЗАГРУЗКИ НАЖМИТЕ R!");
    }

    private void HandleRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}