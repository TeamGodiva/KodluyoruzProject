﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintMap : MonoBehaviour
{
    [SerializeField] private GameObject fullMap;

    public void ReminderButtonOnClick()
    {
        fullMap.SetActive(true);
        StartCoroutine(GameNavCoroutine());
    }

    private IEnumerator GameNavCoroutine()
    {
        yield return new WaitForSeconds(UIController.HighlightedDuration);
        fullMap.SetActive(false);
        GameController.Instance.CloseNavigation();
    }
}