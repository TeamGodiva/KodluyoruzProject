using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private SphereController[] sphereControllers;
    [SerializeField] private Vector3 carPosition;
    private int _coloredSphereCount;
    private float _timeToFinishTheLevel;
    private float _sphereMultiplier = 3f;

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
            if (sphereController.IsPainted())
                _coloredSphereCount++;
        }
    }

    public int GetNumberOfSphereRequiredColor()
    {
        Debug.Log(_coloredSphereCount);
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