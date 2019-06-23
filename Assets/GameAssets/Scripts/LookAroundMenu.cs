using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.mousePresent) return;
        Vector3 mPos = new Vector3(
            (Input.mousePosition.x / (float) Screen.width - 0.5f) * 2,
            (Input.mousePosition.y / (float) Screen.height - 0.5f) * 2,
            0
        );
        Debug.Log(mPos);
        transform.rotation = Quaternion.Euler(-mPos.y, mPos.x, mPos.z);
    }
}