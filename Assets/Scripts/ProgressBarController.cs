
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Image frontImage;

    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private TextMeshProUGUI nextLevel;

    private int _RequiredProgress;
  
    private float _progressCounter;

    public int RequiredProgress
    {
        get => _RequiredProgress;
        set => _RequiredProgress = value;
    }

    public TextMeshProUGUI CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    public TextMeshProUGUI NextLevel
    {
        get => nextLevel;
        set => nextLevel = value;
    }

    public void ResetVar()
    {
     
        _progressCounter = 0;
    }

    public void IncreaseProgress()
    {
        _progressCounter++;
        frontImage.DOFillAmount(_progressCounter / (RequiredProgress),1f);
    }
    
    public void LoadLevelText(int index)
    {
        currentLevel.SetText(""+(index+1));
        nextLevel.SetText(""+(index+2));
    }
}