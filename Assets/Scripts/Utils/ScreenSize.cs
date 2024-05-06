using UnityEngine;

public static class ScreenSize
{
    public static Vector2 TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    public static Vector2 BottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
}
