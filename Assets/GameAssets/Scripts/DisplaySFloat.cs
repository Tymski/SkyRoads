using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DisplaySFloat : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] ScriptableFloat sfloat;
    [SerializeField] int precision;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = System.Math.Round(sfloat.value, precision).ToString();
    }
}