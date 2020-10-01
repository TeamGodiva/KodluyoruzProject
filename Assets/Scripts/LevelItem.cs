using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private int numberOfSphereRequiredColor;
    [SerializeField] private float timeToFinishTheLevel;
    [SerializeField] private float timeToNavigatePuzzle;


    public int NumberOfSphereRequiredColor
    {
        get => numberOfSphereRequiredColor;
    }

    public float TimeToFinishTheLevel
    {
        get => timeToFinishTheLevel;
    }

    public float TimeToNavigatePuzzle
    {
        get => timeToNavigatePuzzle;
        set => timeToNavigatePuzzle = value;
    }
}