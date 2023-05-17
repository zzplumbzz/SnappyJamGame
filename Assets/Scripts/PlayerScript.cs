using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    Vector3 movement;
    public Rigidbody2D rb;

    private float moveSpeed = 5f;
    public bool speedMaskOn;
    private float speedMaskMoveSpeed = 10f;

    private float jumpPower = 6f;   
    public bool canJump;
    public bool jumpMaskOn;
    private float jumpMaskMovePower = 12f;

    public bool canWallJump;

    public bool sizeMaskOn;
    Vector3 regSize = new Vector3(1,1,1);
    Vector3 shrink = new Vector3(0.3f, 0.3f, 0.3f);

    public bool UVisionOn;
    public GameObject[] UVisionOBJ = new GameObject[20];

    public Animator animator;

    public bool facingRight;
    public SpriteRenderer sr;
 
    private GameObject dp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedMaskOn = false;
        jumpMaskOn = false;
        sizeMaskOn = false;
        UVisionOn = false;

        dp = GameObject.Find("DeathPlane");

        UVisionOBJ[0] = GameObject.Find("Switch");
        UVisionOBJ[1] = GameObject.Find("Switch2");
        UVisionOBJ[2] = GameObject.Find("Switch3");
        UVisionOBJ[3] = GameObject.Find("Switch4");
        UVisionOBJ[17] = GameObject.Find("Switch5");
        UVisionOBJ[18] = GameObject.Find("Switch6");

        UVisionOBJ[4] = GameObject.Find("UVisionWall");
        UVisionOBJ[5] = GameObject.Find("UVisionWall2");
        UVisionOBJ[6] = GameObject.Find("UVisionWall3");
        UVisionOBJ[7] = GameObject.Find("UVisionWall4");
        UVisionOBJ[8] = GameObject.Find("UVisionWall5");
        UVisionOBJ[9] = GameObject.Find("UVisionWall6");
        UVisionOBJ[10] = GameObject.Find("UVisionWall7");
        UVisionOBJ[11] = GameObject.Find("UVisionWall8");
        UVisionOBJ[12] = GameObject.Find("UVisionWall9");
        // UVisionOBJ[13] = GameObject.Find("UVisionWall10");
        // UVisionOBJ[14] = GameObject.Find("UVisionWall11");
        // UVisionOBJ[15] = GameObject.Find("UVisionWall12");
        UVisionOBJ[16] = GameObject.Find("UVisionWall13");
       // UVisionOBJ[11] = GameObject.Find("UVisionWall8");
        
        //UVisionOBJ.GetComponent<SpriteRenderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (movement.x > 0)
        // {
        //     facingRight = true;
        //     sr.flipX = facingRight;
        // }
        // else if (movement.x < 0)
        // {
        //     facingRight = false;
        //     sr.flipX = !facingRight;
        // }

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetBool("WSpeedMask",speedMaskOn);
        animator.SetBool("JumpMask", jumpMaskOn);
        animator.SetBool("ShrinkMask", sizeMaskOn);
        animator.SetBool("UVision", UVisionOn);

        movement.x = Input.GetAxisRaw("Horizontal");

        if(canJump == true)
        {
            if (jumpMaskOn == false && Input.GetKeyDown(KeyCode.W) /*|| Input.GetKeyDown(KeyCode.Space)*/)
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpPower);
            }
            else if (jumpMaskOn == true && Input.GetKeyDown(KeyCode.W) /*|| Input.GetKeyDown(KeyCode.Space)*/)
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpMaskMovePower);
            }

            if(jumpMaskOn == false && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpPower);
            }
            else if (jumpMaskOn == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpMaskMovePower);
            }
        }

        if (canWallJump == true)
        {
            if (jumpMaskOn == false && Input.GetKeyDown(KeyCode.W) /*|| Input.GetKeyDown(KeyCode.Space)*/)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (jumpMaskOn == true && Input.GetKeyDown(KeyCode.W) /*|| Input.GetKeyDown(KeyCode.Space)*/)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpMaskMovePower);
            }

            if (jumpMaskOn == false && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (jumpMaskOn == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpMaskMovePower);
            }
        }

        

        if(speedMaskOn == false && Input.GetKeyDown(KeyCode.P))
        {
            speedMaskOn = true;
            jumpMaskOn = false;
            sizeMaskOn = false;
            UVisionOn = false;
            player.transform.localScale = regSize;
        }
        else if (speedMaskOn == true && Input.GetKeyDown(KeyCode.P))
        {
            speedMaskOn = false;
        }

        if(jumpMaskOn == false && Input.GetKeyDown(KeyCode.O))
        {
            jumpMaskOn = true;
            speedMaskOn = false;
            sizeMaskOn = false;
            UVisionOn = false;
            player.transform.localScale = regSize;
        }
        else if(jumpMaskOn == true && Input.GetKeyDown(KeyCode.O))
        {
            jumpMaskOn = false;
        }

        if(sizeMaskOn == false && Input.GetKeyDown(KeyCode.I))
        {
            sizeMaskOn = true;
            speedMaskOn = false;
            jumpMaskOn = false;
            UVisionOn = false;
            player.transform.localScale = shrink;
        }
        else if(sizeMaskOn == true && Input.GetKeyDown(KeyCode.I))
        {
            sizeMaskOn = false;
            player.transform.localScale = regSize;
        }

        if(sizeMaskOn == true)
        {
            speedMaskOn = false;
            jumpMaskOn = false;
            UVisionOn = false;
        }

        if(UVisionOn == false && Input.GetKeyDown(KeyCode.U))
        {
            UVisionOn = true;
            sizeMaskOn = false;
            speedMaskOn = false;
            jumpMaskOn = false;
            player.transform.localScale = regSize;
            ToggleVisionOBJ(UVisionOn);

        }
        else if (UVisionOn == true && Input.GetKeyDown(KeyCode.U))
        {
            UVisionOn = false;
            ToggleVisionOBJ(UVisionOn);
            
        }

        if(sizeMaskOn == false)
        {
            player.transform.localScale = regSize;
        }

        if(UVisionOn == false)
        {
            ToggleVisionOBJ(UVisionOn);
        }
        else
        {
            sizeMaskOn = false;
            speedMaskOn = false;
            jumpMaskOn = false;
        }

    }

    private void ToggleVisionOBJ(bool visionOn)
    {
        UVisionOBJ[0].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[1].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[2].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[3].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[4].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[5].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[6].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[7].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[8].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[9].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[10].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[11].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[12].GetComponent<SpriteRenderer>().enabled = visionOn;
        // UVisionOBJ[13].GetComponent<SpriteRenderer>().enabled = visionOn;
        // UVisionOBJ[14].GetComponent<SpriteRenderer>().enabled = visionOn;
        // UVisionOBJ[15].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[16].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[17].GetComponent<SpriteRenderer>().enabled = visionOn;
        UVisionOBJ[18].GetComponent<SpriteRenderer>().enabled = visionOn;
       // UVisionOBJ[5].GetComponent<SpriteRenderer>().enabled = visionOn;
    }

    private void FixedUpdate() 
    {
        

        if(speedMaskOn == true)
        {
            rb.velocity = new Vector2(movement.x * speedMaskMoveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (other.CompareTag("Wall"))
        {
            canJump = true;
        }

        

        if(other.CompareTag("DeathPlane"))
        {
            rb.velocity = new Vector3(0,0,0);

            UVisionOn = false;
            sizeMaskOn = false;
            speedMaskOn = false;
            jumpMaskOn = false;
        }

        if(other.CompareTag("C2"))
        {
            dp.GetComponent<DeathPlaneScript>().SP2A = true;
            dp.GetComponent<DeathPlaneScript>().SP3A = false;
            dp.GetComponent<DeathPlaneScript>().SP4A = false;
        }

        if (other.CompareTag("C3"))
        {
            dp.GetComponent<DeathPlaneScript>().SP2A = false;
            dp.GetComponent<DeathPlaneScript>().SP3A = true;
            dp.GetComponent<DeathPlaneScript>().SP4A = false;
        }

        if (other.CompareTag("C4"))
        {
            dp.GetComponent<DeathPlaneScript>().SP2A = false;
            dp.GetComponent<DeathPlaneScript>().SP3A = false;
            dp.GetComponent<DeathPlaneScript>().SP4A = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Platform"))
        {
            canJump = true;

            other.gameObject.GetComponent<HPlatform>();
            other.gameObject.GetComponent<VPlatform>();
            //other.gameObject.GetComponent<RotatingPlatform>();
            transform.SetParent(other.gameObject.transform.parent);
        }


        if (other.CompareTag("VPlatform"))
        {
            canJump = true;

            other.gameObject.GetComponent<HPlatform>();
            other.gameObject.GetComponent<VPlatform>();
            //other.gameObject.GetComponent<RotatingPlatform>();
            transform.SetParent(other.gameObject.transform);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Ground"))
        {
            canJump = false;
        }

        if (other.CompareTag("Wall"))
        {
            canJump = false;
        }

        if (other.CompareTag("Platform"))
        {
            canJump = false;

            player.transform.SetParent(null);
        }

        if (other.CompareTag("VPlatform"))
        {
            canJump = false;

            player.transform.SetParent(null);
        }
    }
}
