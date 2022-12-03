using UnityEngine;

public class Pin : MonoBehaviour
{
    [Header("Pin Configuration")]
    [SerializeField] private PinScriptableObject _pinConfig;

    private int _pinValue;

    private void Awake()
    {
        Material pinMaterial = GetComponent<Renderer>().material;
        pinMaterial.color = _pinConfig.pinColor;

        _pinValue = _pinConfig.pinValue;
    }
    ///
    public int PinValue
    {
        get => _pinValue;
    }

}
