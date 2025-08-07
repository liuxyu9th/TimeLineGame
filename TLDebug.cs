using System;
using System.Collections.Generic;
using System.Text;

enum ELogType
{
    Message,
    Error,
    Warning,
}
class TLDebug
{
    public static void Log(ELogType logType,string meg)
    {
        Console.WriteLine(meg);
    }
    public static void LogError(string meg)
    {
        Log(ELogType.Error, meg);
    }
}

