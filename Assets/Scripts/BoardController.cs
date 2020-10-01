using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;
    private int _numberOfSphereRequiredColor;
    [SerializeField] private float timeToFinishTheLevel;


    private void Awake()
    {
        CountPaintedSpheres();
    }

    public void HighlightSpheres()
    {
        foreach (var sphereController in sphereControllers)
        {
            sphereController.HighlightPaintedSphere();
        }
    }

    public void CountPaintedSpheres()
    {
        foreach (var sphereController in sphereControllers)
        {
            if (sphereController.IsPainted())
                _numberOfSphereRequiredColor++;
        }

        Debug.Log(_numberOfSphereRequiredColor);
    }

    public int GetNumberOfSphereRequiredColor()
    {
        return _numberOfSphereRequiredColor;
    }

    public float GetTimeToFinishTheLevel()
    {
        return timeToFinishTheLevel;
    }
}