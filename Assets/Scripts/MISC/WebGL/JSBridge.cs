using System.Runtime.InteropServices;
using UnityEngine;

public static class JSBridge
{
    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void SendStringMessage(string message);
    [DllImport("__Internal")]
    private static extern void SignalHighscore(int highscore);
    #endif

    public static void SendStringMessageToJS(string message)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            SendStringMessage(message);
        #endif
    }

    public static void SendHighscoreSignal(int highscore)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            SignalHighscore(highscore);
        #endif
    }
}