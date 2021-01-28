using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonAsComponent<LevelController>
{
    public static LevelController Instance
    {
        get => ((LevelController)_Instance);
        set => _Instance = value;
    }

    public delegate void TryOpenDoor();
    public event TryOpenDoor OpenDoor;

    public delegate void TryFinish();
    public event TryFinish Finish;

    public void Open()
    {
        OpenDoor?.Invoke();
    }

    public void FinishLevel()
    {
        Finish?.Invoke();
    }
}
