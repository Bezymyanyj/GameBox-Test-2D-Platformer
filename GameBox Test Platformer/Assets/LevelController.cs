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

    public void Open()
    {
        OpenDoor?.Invoke();
    }
}
