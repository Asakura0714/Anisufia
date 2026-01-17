using System;
using static InspectorDescriptionAttribute;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class InspectorDescriptionAttribute : Attribute
{
    public enum EDescriptionType
    {
        Info,
        Warning,
        Error
    }

    public string Description { get; private set; }

    public EDescriptionType DescriptionType { get; private set; }

    public InspectorDescriptionAttribute(string inDescription, EDescriptionType inType)
    {
        Description = inDescription;
        DescriptionType = inType;
    }
}