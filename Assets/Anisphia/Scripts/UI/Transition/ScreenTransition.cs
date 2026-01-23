using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class ScreenTransition : MonoBehaviour
{
    public enum EFadeType
    {
        FadeIn,
        FadeOut
    }

    [SerializeField] private Color _transitionColor = Color.red;
    [SerializeField] private float _scaleTime = 1f;
    [SerializeField] private EFadeType _fadeType = EFadeType.FadeIn;

    private List<Image> _imageList;

    /// <summary>
    /// フェード初期目標の透明度を取得
    /// </summary>
    private float StartScaleY => (_fadeType == EFadeType.FadeOut) ? 1f : 0f;

    /// <summary>
    /// フェード目標のアルファ値を取得
    /// </summary>
    private float TargetScaleY => (_fadeType == EFadeType.FadeIn) ? 1f : 0f;

    public void Setup()
    {
        _imageList = GetComponentsInChildren<Image>().ToList();

        if (_imageList.Count <= 0)
        {
            Debug.LogError("トランジションのImage取得に失敗しました");
            return;
        }

        foreach (var image in _imageList)
        {
            //Fadeの色を変更
            image.color = _transitionColor;

            //初期スケール値をセット
            image.transform.localScale = new Vector3(1f, StartScaleY, 1f);
        }
    }

    /// <summary>
    /// トランジション開始
    /// </summary>
    public void PlayTranssition(Action onComplate)
    {
        if(_imageList.Count <= 0)
        {
            return;
        }

        //シーケンスを定義
        DG.Tweening.Sequence fadeSequence = DOTween.Sequence();

        foreach (var image in _imageList)
        {
            fadeSequence.Join(image.transform
                        .DOScaleY(TargetScaleY, _scaleTime))
                        .SetEase(Ease.InOutSine);

        }

        //全ての処理が終わったらコール
        fadeSequence.OnComplete(() =>
        {
            onComplate?.Invoke();
        });
    }
}
