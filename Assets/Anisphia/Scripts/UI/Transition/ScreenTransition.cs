using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenTransition : MonoBehaviour
{
    public enum EFadeType
    {
        FadeIn,
        FadeOut
    }

    [SerializeField] private Color _imageColor = Color.red;
    [SerializeField] private float _scaleTime = 1f;

    private Image[] _imageList;

    public Action FadeComplateAction;

    public void Setup(EFadeType type)
    {
        _imageList = GetComponentsInChildren<Image>();

        if (_imageList.Length <= 0)
        {
            Debug.LogError("ƒgƒ‰ƒ“ƒWƒVƒ‡ƒ“‚ÌImageŽæ“¾‚ÉŽ¸”s‚µ‚Ü‚µ‚½");
            return;
        }

        float target = type == EFadeType.FadeOut ? 1f : 0f;

        foreach (var image in _imageList)
        {
            var scale = image.transform.localScale;
            scale.y = target;
            image.transform.localScale = scale;
            image.color = _imageColor;
        }
    }

    public void OnStart()
    {
        //StartCoroutine(ScaleAnimetion());
    }

    public void ScaleAnimetion(EFadeType type)
    {
        float target = type == EFadeType.FadeOut ? 1f : 0f;

        foreach (var image in _imageList)
        {
            image.transform.DOScaleY(target, _scaleTime)
                           .SetEase(Ease.InOutSine)
                           .OnComplete(() => FadeComplateAction?.Invoke());
        }
    }
}
