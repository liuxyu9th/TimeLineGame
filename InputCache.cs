
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

public class InputData
{
    public int MoveYaw;
    public bool Key_Interaction_Pressed;
}
public static class InputCache
{
    private static volatile InputData _currentInput;

    public static void SetInput(InputData inputData)
    {
        _currentInput = inputData;
    }

    public static InputData GetInput()
    {
        return _currentInput;
    }
}

