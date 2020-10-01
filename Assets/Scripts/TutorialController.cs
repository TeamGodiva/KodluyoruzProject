using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TutorialController : MonoBehaviour
{
    //Take object transform and choose what will do it with dotween.

    // [SerializeField] private Transform[] tutorialObjects;
    [SerializeField] private Transform CarPosition;
    [SerializeField] private RectTransform fingerIcon;
    [SerializeField] private RectTransform clickIcon;
    [SerializeField] private MoveController carController;


    private Vector3 CarFirsPos;

    void Start()
    {
        //save to restart.
        CarFirsPos = CarPosition.position;
        StartCoroutine(StartTutorialAnim(1));
    }


    IEnumerator StartTutorialAnim(float i)
    {
        yield return new WaitForSeconds(i);
        Animation();
    }

    void Animation()
    {
        fingerIcon.DOAnchorPos(new Vector2(-71, 115), 1.5f).OnComplete(() =>
        {
            ShowClickAnimation(-1);
            carController.RotateLeft();
            fingerIcon.DOAnchorPos(new Vector2(113, 115), 3f).OnComplete(() =>
            {
                ShowClickAnimation(1);
                carController.RotateRight();
                fingerIcon.DOAnchorPos(new Vector2(-71, 115), 3f).OnComplete(() =>
                {
                    ShowClickAnimation(-1);
                    carController.RotateLeft();
                    fingerIcon.DOAnchorPos(new Vector2(113, 115), 3f).OnComplete(() =>
                    {
                        ShowClickAnimation(1);
                        carController.RotateRight();
                        ReStart();
                    });
                });
            });
        });
    }


    private void ShowClickAnimation(int i)
    {
        clickIcon.anchoredPosition = new Vector2(i * 93, 136);
        clickIcon.transform.GetComponent<Image>().DOFade(1, 0f).From(0).OnComplete(() =>
        {
            clickIcon.transform.GetComponent<Image>().DOFade(0, 0.4f).From(1);
        });
    }

    void ReStart()
    {
        CarPosition.position = CarFirsPos;
        Animation();
    }
}