using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadBlue(string name)
    {
        FadeScene.Load(name, new Color(.3f, .3f, .5f, 1f), 2f);
    }
}