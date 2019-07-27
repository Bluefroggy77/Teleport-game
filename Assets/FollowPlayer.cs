using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothness;
    public Vector3 offset;
    Vector3 desiredPos;
    Vector3 smooothPos;

    void Update()
    {
        desiredPos = player.transform.position + offset;
        smooothPos = Vector3.Lerp(transform.position, desiredPos, smoothness);
        transform.position = smooothPos;

        transform.LookAt(player.transform);
    }
}
