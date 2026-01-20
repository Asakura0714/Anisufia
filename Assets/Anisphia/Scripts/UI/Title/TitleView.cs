using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField] private AnisButtonBase _toStageSelectButton = default;
    [SerializeField] private AnisButtonBase _toSettingButton = default;
    [SerializeField] private AnisButtonBase _toGameExitButton = default;

    /// <summary>
    /// ステージ選択ボタンを押下時の処理を登録
    /// </summary>
    public Action OnClickStageSelectAction;

    /// <summary>
    /// 設定ボタンを押下時の処理を登録
    /// </summary>
    public Action OnClickSettingAction;

    /// <summary>
    /// ゲーム終了時のボタンを押下時の処理を登録
    /// </summary>
    public Action OnClickExitAction;

    public void Init()
    {
        //ステージ選択押下時
        _toStageSelectButton.Init(OnClickStageSelectAction);

        //設定ボタン押下時
        _toSettingButton.Init(OnClickSettingAction);

        //ゲーム終了時ボタン
        _toGameExitButton.Init(OnClickExitAction);
    }
}
