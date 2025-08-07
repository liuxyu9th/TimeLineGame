using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


public class ComponentPool
{
    private Dictionary<EComType, Type> typeComDic;

    private void Init()
    {
        if (typeComDic != null)
            return;

        typeComDic = new Dictionary<EComType, Type>();

        var assembly = Assembly.GetExecutingAssembly();
        foreach (var type in assembly.GetTypes())
        {
            if (type.IsSubclassOf(typeof(Component)))
            {
                if (type.IsDefined(typeof(ComTypeAttribute), false))
                {
                    var attribute = type.GetCustomAttribute<ComTypeAttribute>(false);
                    typeComDic[attribute.comType] = type;
                }
            }
        }
        _cacheDic = new Dictionary<EComType, Queue<Component>>();
    }

    private Component InstantiateComponent(EComType comType, uint id)
    {
        Init();
        if (!typeComDic.TryGetValue(comType, out var type))
        {
            return null;
        }

        var com = Activator.CreateInstance(type, new object[] { id, comType }) as Component;
        return com;
    }
    private static ComponentPool _instance;

    public static ComponentPool instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ComponentPool();
            }
            return _instance;
        }
    }

    private Dictionary<EComType, Queue<Component>> _cacheDic;
    private int _buffCount;

    public ComponentPool()
    {
        Init();
        _buffCount = 5;
    }

    public T Get<T>(EComType comType,uint entityId)where T:Component
    {
        if (_cacheDic.ContainsKey(comType))
        {
            if (_cacheDic[comType].Count <= _buffCount)
            {
                _cacheDic[comType].Enqueue(InstantiateComponent(comType, entityId));
            }
        }
        else
        {
            Queue<Component> components = new Queue<Component>();
            components.Enqueue(InstantiateComponent(comType, entityId));
            _cacheDic.Add(comType, components);
        }
        return _cacheDic[comType].Dequeue() as T;

    }


    public void Release(Component obj)
    {
        _cacheDic[obj.comType].Enqueue(obj);
    }

    public void Clear()
    {
        _cacheDic.Clear();

    }
}


