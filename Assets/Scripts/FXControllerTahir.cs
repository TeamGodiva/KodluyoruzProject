using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXControllerTahir : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] ConfettiFX;

    private void StartConfettiFX()
    {
        for (int i = 0; i < ConfettiFX.Length; i++)
        {
            ConfettiFX[i].Play(true);
        }
    }

    private void Start()
    {
        StartConfettiFX();
    }
}
