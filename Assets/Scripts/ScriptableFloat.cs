using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Float", menuName = "Scriptable/Float", order = 1)]
public class ScriptableFloat : ScriptableObject
{
    [SerializeField] float startValue;
    [SerializeField] float runtimeValue;

    private void Awake()
    {
        runtimeValue = startValue;
    }

    public float value
    {
        get { return runtimeValue; }
        set { runtimeValue = value; }
    }

}