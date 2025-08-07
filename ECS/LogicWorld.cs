using System;
using System.Collections.Generic;
using System.Text;

class FrameData
{
    public Dictionary<EComType, List<Component>> TypeComDic = new Dictionary<EComType, List<Component>>();
    public Dictionary<uint, List<Component>> EntityComDic = new Dictionary<uint, List<Component>>();

    public void AddCom(Component com)
    {
        uint entityId = com.EntityID;
        EComType comType = com.comType;
        if(EntityComDic.ContainsKey(entityId))
        {
            EntityComDic[entityId].Add(com);
        }
        else
        {
            EntityComDic.Add(entityId, new List<Component> { com });
        }
        if(TypeComDic.ContainsKey(comType))
        {
            TypeComDic[comType].Add(com);
        }
        else
        {
            TypeComDic.Add(comType, new List<Component> { com });
        }

    }
    public void AddRange(List<Component> coms)
    {
        foreach(var com in coms)
        {
            AddCom(com);
        }
    }
    public FrameData Clone()
    {
        FrameData cloneData = new FrameData();
        foreach (var item in TypeComDic)
        {
            List<Component> cloneComList = new List<Component>(item.Value.Capacity);
            foreach (var com in item.Value)
            {
                Component cloneCom = com.Clone();
                cloneComList.Add(cloneCom);
                if(cloneData.EntityComDic.ContainsKey(cloneCom.EntityID))
                {
                    cloneData.EntityComDic[com.EntityID].Add(cloneCom);
                }
                else
                {
                    cloneData.EntityComDic.Add(cloneCom.EntityID, new List<Component>() { cloneCom });
                }
            }
            cloneData.TypeComDic.Add(item.Key, cloneComList);
        }

        return cloneData;
    }
}
class LogicWorld
{
    private LogicTimeLine timeLine;
    public FrameData FrameData;
    public List<LogicSystem> logicSystems; 
    public LogicWorld()
    {
        timeLine = new LogicTimeLine(this);
        logicSystems = new List<LogicSystem>();
        FrameData = new FrameData();
    }
    public void AddCom(Component com)
    {
        FrameData.AddCom(com);
    }
    public void Update()
    {
        foreach (var logicSystem in logicSystems)
        {
            logicSystem.Update();
        }
        timeLine.Update();
    }
}
