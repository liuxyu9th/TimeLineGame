using System;
using System.Collections.Generic;
using System.Text;
struct Vector3
{

}
[ComType(EComType.ComTransform)]
class ComTransform:Component
{
    public Vector3 pos;
    public Vector3 rotation;

    public ComTransform(uint id,EComType comType):base(id,comType)
    {

    }

    public override Component Clone()
    {
        throw new NotImplementedException();
    }
}