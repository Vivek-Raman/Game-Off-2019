using UnityEngine;

public static class ExtensionFunctions
{
    public static Vector3 ToVector3(this Vector2 toConvert)
    {
        return new Vector3(toConvert.x, toConvert.y, 0f);        
    }
}