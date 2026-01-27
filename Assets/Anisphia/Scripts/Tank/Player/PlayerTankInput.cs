using UnityEngine;
using UnityEngine.InputSystem.UI;

public class PlayerTankInput : MonoBehaviour
{
    [SerializeField] private VirtualMouseInput _virtualMouseInput;

    /// <summary>
    /// 基本は等倍※後で設定からここを操作して感度を変える
    /// </summary>
    private float sensitivity = 1f;

    /// <summary>
    /// ここは変更しない
    /// </summary>
    private float CursolMoveSpeed = 1000f;

    private Transform _myTransform;
    private Vector2 _cursorSize;

    public void Setup()
    {
        _myTransform = _virtualMouseInput.cursorTransform;
        var rectTrans = _virtualMouseInput.cursorTransform;

        _cursorSize = new Vector2(rectTrans.rect.width / 2f, rectTrans.rect.height / 2f);
    }

    public void MoveMouceCursol(Vector2 inputAxis)
    {
        //移動量の計算
        _myTransform.position += GetCursolSpeed(inputAxis);

        //画面範囲外を調べる
        SetScreenLimitPosition();
    }

    private Vector3 GetCursolSpeed(Vector2 inputAxis)
    {
        var velo = inputAxis * sensitivity * CursolMoveSpeed * Time.deltaTime;
        return new Vector3(velo.x, velo.y, 0f);
    }

    /// <summary>
    /// マウスカーソルの表示制御を行う
    /// </summary>
    /// <param name="isSetActive"></param>
    public void SetSetActiveMouseCursor(bool isSetActive)
    {
        _virtualMouseInput.cursorGraphic.gameObject.SetActive(isSetActive);
    }

    private void SetScreenLimitPosition()
    {
        //マウスカーソルの半分の値を取得
        float halfWidth = _cursorSize.x;
        float halfHeight = _cursorSize.y;

        //値の丸め込み
        float clampedX = Mathf.Clamp(_myTransform.position.x, halfWidth, Screen.width - halfWidth);
        float clampedY = Mathf.Clamp(_myTransform.position.y, halfHeight, Screen.height - halfHeight);

        _myTransform.position = new Vector3(clampedX, clampedY, 0f);
    }
}
