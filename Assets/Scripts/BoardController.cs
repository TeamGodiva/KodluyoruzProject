using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;
    [SerializeField] private Vector3 carPosition;
    private int _numberOfSphereRequiredColor;
    private float _timeToFinishTheLevel;
    private float _sphereMultiplier = 3f;

    private void OnEnable()
    {
        CountPaintedSpheres();
        _timeToFinishTheLevel = _numberOfSphereRequiredColor * _sphereMultiplier;
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
        return _timeToFinishTheLevel;
    }

    public Vector3 GetCarPosition()
    {
        return carPosition;
    }
}