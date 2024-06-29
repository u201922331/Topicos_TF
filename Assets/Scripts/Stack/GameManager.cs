using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _menuContainer;
    [SerializeField] private GameObject _endGameContainer;
    [SerializeField] private TMPro.TextMeshProUGUI _playerScore;
    [SerializeField] private TMPro.TextMeshProUGUI _endGameScore;
    public bool GameEnd = false;
    int _currentScore = 0;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void AddScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _playerScore.text = "Score: " + _currentScore.ToString();
    }

    public void StartGame()
    {
        GameEnd = false;
        _menuContainer.SetActive(false);
        EventManager.OnTimerStart();
        CamionController.Instance.ActiveDrop(true);
    }

    public void ResetGame()
    {
        GameEnd = false;

        _endGameContainer.SetActive(false);

        PenguinMovement.instance.RevivirPinguino();
        EventManager.OnTimerStart();
        CamionController.Instance.ActiveDrop(true);
        _currentScore = 0;
        _playerScore.text = "Score: " + _currentScore.ToString();
        BolsaStack.Instance.ResetStack();
    }

    public void EndGame()
    {
        GameEnd = true;

        _endGameContainer.SetActive(true);
        _endGameScore.text = _playerScore.text;
        CamionController.Instance.ActiveDrop(false);
        EventManager.OnTimerStop();
    }
}
