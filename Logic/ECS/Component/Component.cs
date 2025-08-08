using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
public enum EComType
{
    ComTransform,
}
public abstract class Component
{
    public uint EntityID { get; private set; }
    public EComType comType { get; private set; }
    public Component(uint entityID,EComType comType)
    {
        EntityID = entityID;
        this.comType = comType;
    }
    public abstract Component Clone();


}
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
class ComTypeAttribute : Attribute
{
    public EComType comType { get; }

    public ComTypeAttribute(EComType comType) => this.comType = comType;
}

