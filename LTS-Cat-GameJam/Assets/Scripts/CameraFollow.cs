using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float offsetX;
    private float offsetY = -8f;
    private float offsetZ = -8f;

    private void Update()
    {
        transform.position = new Vector3 (player.transform.position.x + offsetX, player.transform.position.y + offsetY, offsetZ);
    }
}
