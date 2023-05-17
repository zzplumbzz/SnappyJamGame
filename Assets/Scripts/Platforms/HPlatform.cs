using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlatform : MonoBehaviour
{
    [Header("Horizontal")]
    public Transform hPos1, hPos2;
    public float horizontalSpeed;
    public Transform startHPos;
    Vector3 nextHPos;
    void Start()
    {
        nextHPos = startHPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == hPos1.position)
        {
            nextHPos = hPos2.position;
        }
        if (transform.position == hPos2.position)
        {
            nextHPos = hPos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextHPos, horizontalSpeed * Time.deltaTime);

    }
}
