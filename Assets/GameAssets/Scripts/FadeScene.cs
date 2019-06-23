using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeScene : MonoBehaviour
{
    public static void Reload(Color color = new Color(), float multiplier = 2f)
    {
        if (color.Equals(new Color())) color = Color.black;
        Initiate.Fade(SceneManager.GetActiveScene().name, color, multiplier);
    }

    public static void Load(string scene, Color color, float multiplier)
    {
        Initiate.Fade(scene, color, multiplier);
    }
}