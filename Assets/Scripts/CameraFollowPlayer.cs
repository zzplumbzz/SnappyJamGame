using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


private void Start() {
        transform.position = player.position + offset;
}

    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = player.position + offset;//camera follows target on update( target should be player)

    // }

    void FixedUpdate()
    {
        Vector3 finalPosition = player.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed);
        transform.position = lerpPosition;
    }
}
