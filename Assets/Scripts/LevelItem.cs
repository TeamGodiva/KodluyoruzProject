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
        set => numberOfSphereRequiredColor = value;
    }

    public float TimeToFinishTheLevel
    {
        get => timeToFinishTheLevel;
        set => timeToFinishTheLevel = value;
    }

    public float TimeToNavigatePuzzle
    {
        get => timeToNavigatePuzzle;
        set => timeToNavigatePuzzle = value;
    }
}
