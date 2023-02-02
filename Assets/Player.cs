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

    private void Start()
    {
        healthPoint = UIManager.instance.hearts.Count;
    }

    private void Update()
    {
        
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

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
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

}

