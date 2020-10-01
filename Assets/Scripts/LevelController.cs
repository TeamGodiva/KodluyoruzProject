using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] levels; //Contains LevelItemScripts To Determine Level Properties.
    [SerializeField] private HintMap hintMap;
    [SerializeField] private ProgressBarController progressBarController;
    [SerializeField] private CountDownTimerController countDownTimerController;
    private BoardController _boardController;
    private GameObject _currentLevel;
    private int _progressCount;
    private int _requiredProgress;
    private static int _index; // it refers current level that represents to user as a game map.


    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        LoadMapArea();
        _boardController = FindObjectOfType<BoardController>();
        _requiredProgress = _boardController.GetNumberOfSphereRequiredColor();
        LoadProgressBar();
        LoadCountdownTimer();
    }


    public void HighlightSquares()
    {
        hintMap.ReminderButtonOnClick();
        _boardController.HighlightSpheres();
    }


    public void LoadNextLevel()
    {
        DestroyLevel();
        IncreaseLevelIndex();
        LoadLevel();
    }

    private void LoadMapArea()
    {
        _currentLevel = Instantiate(levels[_index]);
    }

    public void RestartLevel()
    {
        DestroyLevel();
        DecreaseIndex();
        _currentLevel = Instantiate(levels[_index]);
        HighlightSquares();
    }

    private void IncreaseLevelIndex()
    {
        if (_index < levels.Length - 1)
            _index++;
    }

    private void DecreaseIndex()
    {
        if (_index > 0 && _index != levels.Length - 1)
            _index--;
    }

    public void DestroyLevel()
    {
        if (_currentLevel)
            Destroy(_currentLevel);
    }


    public void IncreaseLevelProgress()
    {
        _progressCount++;
        progressBarController.IncreaseProgress();
        if (IsLevelCompleted())
        {
            LevelIsCompleted();
        }
    }

    private bool IsLevelCompleted()
    {
        return _progressCount == _requiredProgress;
    }

    public void LevelIsCompleted()
    {
        GameController.Instance.LevelCompleted();
    }

    public void LoadProgressBar()
    {
        progressBarController.RequiredProgress = _boardController.GetNumberOfSphereRequiredColor();
        progressBarController.LoadLevelText(_index);
    }


    public void LoadCountdownTimer()
    {
        countDownTimerController.TimeLeft = _boardController.GetTimeToFinishTheLevel();
        countDownTimerController.StartCountDownTimer();
    }


    public void StartOrStopTimer()
    {
        countDownTimerController
            .ChangeTimerState(); //this function changes the timer state if timer already started this function stop the timer.
    }
}