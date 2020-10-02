﻿using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public LevelController levelController;
    public MoveController carController;
    public UIController uiController;
    public GameObject partSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CubeIsColored()
    {
        // this function is triggered from sphere trigger collider when the car is collided with sphere.
        levelController.IncreaseLevelProgress();
    }

    public void LevelCompleted()
    {
        //This is triggered from LevelController when the level is completed successfully;
        carController.ChangeState(); //its stop the car.
        ActivateCompleteParticleSystem();
        uiController.ShowLevelCompletedText();
    }

    private void ActivateCompleteParticleSystem()
    {
        //TODO bu nasıl isimdir yiğidim.
        partSystem.SetActive(true);
    }


    private void DeActiveParticle()
    {
        partSystem.SetActive(false);
    }

    public void StartNavigation() //When user tap to start game. this function is called.
    {
        //After navigation end start the time and set active game play buttons.
        uiController.StartNavigation();
        levelController.HighlightSquares();
        //after Highlight navigation close is called. and GameEnvironments are called from ui controller.
    }

    public void CloseNavigation()
    {
        uiController.CloseNavigationElements();
    }

    public void StartTimerAndCarMovement()
    {
        levelController.StartTimer();
        carController.MoveCar();
        uiController.ScreenButtonsAvailable();
    }

    private void LoadNextLevel()
    {
        levelController.LoadNextLevel();
        uiController.OpenMainScreenEnvironments();
        gameObject.GetComponent<TabToStart>().isStarted = false;
    }

    public void EndLevelCompletedAndLoadNextLevel()
    {
        DeActiveParticle(); //until load next level, completed text and particle system are closed before load.
        LoadNextLevel();
    }


    public void RestartGame()
    {
        //Load Current Level Open The UI Menu Again
        levelController.RestartLevel();
        carController.ResetCar();
        uiController.OpenMainScreenEnvironments();
        gameObject.GetComponent<TabToStart>().isStarted = false;
    }
}