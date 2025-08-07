using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        GameLogicMain logicMain = GameLogicMain.Instance;
        while(!logicMain.IsEnd)
        {
            long timeBeforeUpdate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            logicMain.Update();
            long timeAfterUpdate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long updateTime = 1000 / logicMain.UpdateRate;
            long sleepTime = updateTime - (timeAfterUpdate - timeBeforeUpdate);
            sleepTime = Math.Clamp(sleepTime, 1, updateTime);
            Thread.Sleep((int)sleepTime);
        }
    }
}
