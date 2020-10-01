using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;

    public void HighlightSpheres()
    {
        foreach (var sphereController in sphereControllers)
        {
            sphereController.HighlightPaintedSphere();
        }
       
    }
}