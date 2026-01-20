using System.Reflection;
using UnityEditor;
using UnityEngine;
using static InspectorDescriptionAttribute;

/// <summary>
/// インスペクターの描画
/// </summary>
[CustomEditor(typeof(MonoBehaviour), true)]
public class InspectorCommentDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        //表示準備
        DrawDescription();
    }

    /// <summary>
    /// インスペクターに説明文を表示するための準備
    /// </summary>
    private void DrawDescription()
    {
        var type = target.GetType();
        var attr = type.GetCustomAttribute<InspectorDescriptionAttribute>();
        if (attr == null)
        {
            return;
        }

        //タイプ変換
        MessageType msgType = GetMessageType(attr.DescriptionType);

        //HelpBoxの作成
        EditorGUILayout.HelpBox(attr.Description, msgType);

        //間を開ける
        EditorGUILayout.Space(10);
    }

    /// <summary>
    /// タイプを変換する
    /// </summary>
    /// <param name="inDescriptionType"></param>
    /// <returns></returns>
    private MessageType GetMessageType(EDescriptionType inDescriptionType)
    {
        MessageType msgType = MessageType.Info;
        switch (inDescriptionType)
        {
            case EDescriptionType.Info:
                {
                    msgType = MessageType.Info;
                    break;
                }
            case EDescriptionType.Warning:
                {
                    msgType = MessageType.Warning;
                    break;
                }
            case EDescriptionType.Error:
                {
                    msgType = MessageType.Error;
                    break;
                }
        }

        return msgType;
    }
}
