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

    public void MoveMouceCursol(Vector2 inputAxis)
    {
        // 3. 移動量の計算
        _virtualMouseInput.cursorTransform.position += GetCursolSpeed(inputAxis);
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
}
