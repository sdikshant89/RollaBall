using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Its a 3d vector which defines the length between the two ganeObject's positions and holds the direction to it as well
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
