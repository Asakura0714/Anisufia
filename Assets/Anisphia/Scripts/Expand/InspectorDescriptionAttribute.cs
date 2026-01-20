using System;

/// <summary>
/// ‘®«‚ÌDataƒNƒ‰ƒX
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class InspectorDescriptionAttribute : Attribute
{
    public enum EDescriptionType
    {
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// •\¦‚·‚é•¶š—ñ
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Log‚Ìí—Ş
    /// </summary>
    public EDescriptionType DescriptionType { get; private set; }

    public InspectorDescriptionAttribute(string inDescription, EDescriptionType inType)
    {
        Description = inDescription;
        DescriptionType = inType;
    }
}