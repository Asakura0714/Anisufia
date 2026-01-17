using ES3Types;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static InspectorDescriptionAttribute;

[CustomEditor(typeof(MonoBehaviour), true)]
public class InspectorCommentDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDescription();
        base.OnInspectorGUI();
    }

    /// <summary>
    /// インスペクターにコメントを表示する
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

        EditorGUILayout.HelpBox(attr.Description, msgType);
        EditorGUILayout.Space();
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
