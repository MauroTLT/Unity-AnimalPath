
using UnityEngine;

public static class GameManager {

    public static Vector3 lastCheckpoint;
    public static int deaths;
    public static bool gamePaused = true;

    public static bool tiltControl = true;
    public static int movX = 0;
    public static int movY = 0;
    public static bool jumping = false;
}
