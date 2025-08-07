using System;
using System.Collections.Generic;
using System.Text;


class LogicTimeLine
{
    public List<FrameData> FrameSnapShot;

    private LogicWorld world;

    public LogicTimeLine(LogicWorld world)
    {
        this.world = world;
        FrameSnapShot = new List<FrameData>();
    }

    public void AddComsAtFrame(int frame,List<Component> coms)
    {
        if(frame >= FrameSnapShot.Count || frame < 0)
        {
            TLDebug.LogError($"Frame {frame} is out of range");
            return;
        }
        FrameSnapShot[frame].AddRange(coms);
    }
    private void CreatSnapShot()
    {
        FrameSnapShot.Add(world.FrameData.Clone());
    }

    public void Update()
    {
        CreatSnapShot();
    }
}

