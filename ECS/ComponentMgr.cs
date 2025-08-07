using System;
using System.Collections.Generic;
using System.Text;

class ComponentMgr
{
    private static ComponentMgr _instance;
    public static ComponentMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ComponentMgr();
            }
            return _instance;
        }
    }

    public T CreatCom<T>(EComType type,uint entityId)where T:Component
    {
        return ComponentPool.instance.Get<T>(type, entityId);
    }
}