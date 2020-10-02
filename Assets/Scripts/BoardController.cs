using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;
    [SerializeField] private float timeToFinishTheLevel;
    [SerializeField] private Vector3 carPosition;
    private int _numberOfSphereRequiredColor;

    private void OnEnable()
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
    }

    public int GetNumberOfSphereRequiredColor()
    {
        return _numberOfSphereRequiredColor;
    }

    public float GetTimeToFinishTheLevel()
    {
        return timeToFinishTheLevel;
    }

    public Vector3 GetCarPosition()
    {
        return carPosition;
    }
}