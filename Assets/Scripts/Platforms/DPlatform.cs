using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlatform : MonoBehaviour
{
    public SpriteRenderer platform;
    public BoxCollider2D disapearCollider;
    public float tick;
    public float timer = 1.5f;
    public bool timerOn;
    public float comebackTimer = 0.5f;
    public bool comebackTimerOn;
    // Start is called before the first frame update
    void Start()
    {
        tick = 0;
        timerOn = false;
        comebackTimerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && tick == 0)
        {
            tick += 1f;
            disapearCollider.enabled = false;
            platform.enabled = false;

            timerOn = false;
            timer = 1.5f;

        }

        if (tick >= 1f)
        {
            comebackTimerOn = true;
        }

        if (comebackTimerOn == true)
        {
            comebackTimer -= Time.deltaTime;
        }

        if (comebackTimer <= 0)
        {
            tick -= 1f;
            disapearCollider.enabled = true;
            platform.enabled = true;
            comebackTimerOn = false;
            comebackTimer = 0.5f;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timerOn = true;

        }
    }
}
