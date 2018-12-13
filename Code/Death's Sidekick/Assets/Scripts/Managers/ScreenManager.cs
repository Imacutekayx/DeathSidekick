using Assets.Scripts.Managers;
using UnityEngine;

/// <summary>
/// Class which manage all the actions between the user and the screen
/// </summary>
public class ScreenManager : MonoBehaviour
{
    //Objects
    public Camera mainCamera;
    public TargetScreenManager targetScreen = new TargetScreenManager();

    //Constructor
    public ScreenManager()
    {
        mainCamera.orthographicSize = Globals.resolution / mainCamera.aspect;
    }

    public void ShowTarget()
    {
        targetScreen.ShowTarget();
    }
}
