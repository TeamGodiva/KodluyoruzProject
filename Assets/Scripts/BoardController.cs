using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;
    [SerializeField] private Vector3 carPosition;
    private int _coloredSphereCount;
    private float _timeToFinishTheLevel;
    private float _sphereMultiplier = 5f;

    private void Awake()
    {
        CountPaintedSpheres();
        _timeToFinishTheLevel = _coloredSphereCount * _sphereMultiplier;
    }

    public void HighlightSpheres()
    {
        foreach (var sphereController in sphereControllers)
        {
            sphereController.HighlightPaintedSphere();
        }
    }

    private void CountPaintedSpheres()
    {
        foreach (var sphereController in sphereControllers)
        {
            if (sphereController.IsPainted() && !sphereController.IsEnemy())
                _coloredSphereCount++;
        }
    }

    public int GetNumberOfSphereRequiredColor()
    {
        return _coloredSphereCount;
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