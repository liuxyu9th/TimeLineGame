using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class GameLogicMain
{
    public bool IsEnd { get; private set; }
    public int UpdateRate { get; private set; }
    public int FrameCount {get; private set; }
    public int DeltaTime { get; private set; }
    private long lastTime = 0;

    private LogicWorld world;
    private static GameLogicMain _instance;
    public static GameLogicMain Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicMain();
            }
            return _instance;
        }
    }

    private GameLogicMain()
    {
        UpdateRate = 15;
        DeltaTime = 1000 / UpdateRate;
        world = new LogicWorld();
    }
    public void Update()
    {
        long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if(FrameCount != 0)
        {
            DeltaTime = (int)(now - lastTime);
        }
        lastTime = now;
        world.Update();
        FrameCount++;
    }
}

