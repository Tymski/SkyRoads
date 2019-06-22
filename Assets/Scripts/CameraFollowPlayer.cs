using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform playerTransform;
    private void FixedUpdate () {
        transform.position = new Vector3 (
            transform.position.x,
            transform.position.y,
            //playerTransform.position.z - 15
            Mathf.Lerp (playerTransform.position.z - 15, playerTransform.position.z - 15, .3f)
        );
    }
}