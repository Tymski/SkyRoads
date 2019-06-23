using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableFloat : ScriptableObject
{
    [SerializeField] float startValue;
    [SerializeField] float runtimeValue;

    private void OnEnable()
    {
        Debug.Log("ScriptableOnEnable");
        runtimeValue = startValue;
    }

    public float value
    {
        get { return runtimeValue; }
        set { runtimeValue = value; }
    }

}