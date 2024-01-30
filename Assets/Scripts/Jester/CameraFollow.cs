using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject gCamera, player;
    public float offset;

    private void Update()
    {
        gCamera.transform.position = new Vector3(gCamera.transform.position.x, player.transform.position.y, gCamera.transform.position.z);
    }
}