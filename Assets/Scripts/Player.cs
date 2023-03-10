using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [Header("General Attribute")]
    public Transform target;
    public Transform rotator;
    public Transform destroyer;
    public Animator animator;
    public Transform cam;
    public Vector3 offset;

    [Header("Player Attribute")]
    public int healthPoint;
    public bool isLeft;
    public float deadTime;
    public float resetTime;
    private Rigidbody2D rb;
    public float jumpForce;
    public float swingForce;

    [Header("Target Attribute")]
    public float targetSpeed;
    public float defaultSpeed;
    public bool isHolding;
    public bool isJump;
    public Vector2 aimLoc;
    public Vector3 worldPos;
    public float holdingTime;
    public float limitHoldingTime;


    [Header("Destroyer Attribute")]
    public Vector2 destroyLoc;
    public Vector3 destroyPos;

    public Transform detectionPoint;
    private const float detectionRadius = .5f;
    public LayerMask platLayer;



    private void Start()
    {
        healthPoint = UIManager.instance.hearts.Count;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Alive() && deadTime > resetTime)
        {
            healthPoint--;
            UIManager.instance.hearts[healthPoint].SetActive(false);
            GameManager.instance.ResetPlayerPosition();

            if (healthPoint < 1) 
            { 
                UIManager.instance.losePanel.SetActive(true); 
            }
            if(healthPoint < 2)
            {
                UIManager.instance.panelWarning.SetActive(true);
            }
        }

        if (isHolding)
        {
            if (!isLeft) 
            { 
                target.transform.localPosition += new Vector3(targetSpeed * Time.deltaTime, targetSpeed * Time.deltaTime); 
            }
            else 
            { 
                target.transform.localPosition += new Vector3(-targetSpeed * Time.deltaTime, targetSpeed * Time.deltaTime); 
            }
            target.gameObject.SetActive(true);

            holdingTime += Time.deltaTime;
            animator.SetFloat("SqueezeValue", holdingTime);

           

            if(holdingTime > limitHoldingTime) 
            { 
                targetSpeed = 0;
            }

            deadTime = 0;
        }
        else
        {
            ResetTarget();
        }

    }
    private void FixedUpdate()
    {
        if (isLeft)
        {
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(-offset.x, offset.y, offset.z), Time.deltaTime);
        }
        else
        {
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(offset.x, offset.y, offset.z), Time.deltaTime);
        }
    }

    public void Jump()
    {   
        
        aimLoc = target.transform.localPosition;
        worldPos = transform.localToWorldMatrix.MultiplyPoint3x4(aimLoc);

        swingForce = holdingTime / 1f;

        if (holdingTime > 0.5f)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (isLeft)
            {
                rb.AddForce(Vector2.left * swingForce, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.right * swingForce, ForceMode2D.Impulse);
            }
            UIManager.instance.jumpButton.SetActive(false);
            DecreaseTargetCount();
        }
        
    }

    public bool Alive()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, platLayer);
    }
    public void ResetTarget()
    {
        target.gameObject.SetActive(false);
        target.transform.localPosition = rotator.localPosition;
        deadTime += Time.deltaTime;
        holdingTime = 0;
        targetSpeed = defaultSpeed;
        animator.SetFloat("SqueezeValue", 0);
    }
    
    public void StartHolding()
    {
        isHolding = true;
    }

    public void StopHolding()
    {
        isHolding = false;
    }



    public void DecreaseTargetCount()
    {
        GameManager.instance.targetCount -= 1;
        if (GameManager.instance.targetCount < 0)
        {
            GameManager.instance.targetCount = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }


}

