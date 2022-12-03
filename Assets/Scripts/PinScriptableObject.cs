using UnityEngine;

[CreateAssetMenu(fileName = "New Pin Config", menuName = "Configs/Pin", order = 0)]
public class PinScriptableObject : ScriptableObject
{
    public Color pinColor;
    public int pinValue;
} 

