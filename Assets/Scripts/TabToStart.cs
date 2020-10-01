using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabToStart : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool isStarted;

    // Update is called once per frame
    void Update()
    {
        if (isStarted) return;
        // Check if there is a touch
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButtonDown(0))
        {
            // Check if finger is over a UI element
            if (EventSystem.current.currentSelectedGameObject == null && !(GameObject.Find("HowToPlay") == null))
            {
                Debug.Log("TAB TO START!!! -->>> TAG");
                StartGame();
                return;
            }

            if (!EventSystem.current.currentSelectedGameObject.CompareTag("UI"))
            {
                Debug.Log("TAB TO START!!! -->>> TAG");
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        isStarted = true;
        GameController.Instance.StartNavigation();
    }
}