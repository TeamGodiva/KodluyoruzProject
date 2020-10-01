using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class SphereController : MonoBehaviour
{
    [SerializeField] private Renderer cubeRenderer;
    [SerializeField] private Color sphereColor;
    [SerializeField] private bool isPaintableSphere;

    private Material[] _cubeMaterials;
    private Material _sphereMaterial;
    private Color _defaultCubeColor;
    private string _color = "_Color";

    void Awake()
    {
        _cubeMaterials = cubeRenderer.materials;
        _sphereMaterial = GetComponent<Renderer>().material;
        _defaultCubeColor = _cubeMaterials[1].color;
    }

    public void HighlightPaintedSphere()
    {
        if (isPaintableSphere)
        {
            _cubeMaterials[1].DOColor(sphereColor, 0.5f)
                .SetLoops((int) (UIController.HighlightedDuration / 0.5) + 2, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    //almost hard coding
                    _cubeMaterials[1].color = _defaultCubeColor;
                });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPaintableSphere)
        {
            //istenmeyen bir sphere toplandı.
        }
        else if (isPaintableSphere && other.CompareTag("Player"))
        {
            GameController.Instance.CubeIsColored();
            _sphereMaterial.color = sphereColor;
            _cubeMaterials[1].color = sphereColor;
            Destroy(gameObject);
        }
    }
}