using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [Header("General Attribute")]
    public Transform target;
    public Transform rotator;
    public Transform destroyer;

    [Header("Player Attribute")]
    public int healthPoint;
    public bool isLeft;

    [Header("Target Attribute")]
    public float targetSpeed;
    public bool isHolding;
    public bool isJump;
    public Vector2 aimLoc;
    public Vector3 worldPos;
    public float duration;


    [Header("Destroyer Attribute")]
    public Vector2 destroyLoc;
    public Vector3 destroyPos;

    public Transform detectionPoint;
    private const float detectionRadius = .5f;
    public LayerMask platLayer;



    private void Start()
    {
        healthPoint = UIManager.instance.hearts.Count;
    }

    private void Update()
    {
        if (!Alive())
        {
            healthPoint--;
            UIManager.instance.hearts[healthPoint].SetActive(false);
            GameManager.instance.ResetPlayerPosition();

            if (healthPoint < 1) { UIManager.instance.gameoverPanel.SetActive(true); }
        }


        if (isHolding && !isLeft) 
        { 
            target.transform.localPosition += new Vector3(targetSpeed * Time.deltaTime, targetSpeed * Time.deltaTime); 
        }
        else if(isHolding && isLeft)
        {
            target.transform.localPosition += new Vector3(-targetSpeed * Time.deltaTime, targetSpeed * Time.deltaTime);
        }
        else
        {
            ResetTarget();  
        }

    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            //transform.position = new Vector2(transform.position, worldPos, 10 * Time.deltaTime);
            

            //duration += Time.deltaTime;
            //duration = duration % 5f;

            //if(duration % 5f > 0)
            //{
            //    transform.position = MathParabola.Parabola(transform.position, worldPos, 0.5f, duration / 1f);
            //}
        }
    }
    public void Charging()
    {
    }
    public void Jump()
    {
        aimLoc = target.transform.localPosition;
        worldPos = transform.localToWorldMatrix.MultiplyPoint3x4(aimLoc);
        transform.position = worldPos;
        DecreaseTargetCount();
    }
    
    public bool Alive()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, platLayer);

    }
    public void ResetTarget()
    {
        target.transform.localPosition = rotator.localPosition;
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

