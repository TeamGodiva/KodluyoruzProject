using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        carController.ChangeState();//its stop the car.
        ActivateCompleteParticleSystem();
        uiController.ShowLevelCompletedText();
        //LoadNewLevel


    }

    private void ActivateCompleteParticleSystem()
    {
        //TODO bu nasıl isimdir yiğidim.
        
        partSystem.SetActive(true);
        StartCoroutine(DeActiveParticle());

    }


    IEnumerator DeActiveParticle()
    {
       yield return new WaitForSeconds(1.5f);
       partSystem.SetActive(false);
    }

    public void StartNavigation() //When user tap to start game. this function is called.
    {
        //close main ui environments - Show navigation
        //close navigation
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
        levelController.StartOrStopTimer();
        carController.MoveCar();
        uiController.ScreenButtonsAvailable();
    }

    public void OnResume()
    {
        //if user click to continue button this function will be called.
        
    }
    
    public void OnStop()
    {
        //Check timer if time is done call this function
        
        
    }
}