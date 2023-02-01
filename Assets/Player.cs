using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Attribute")]
    public Transform target;
    public Transform rotator;

    [Header("Player Attribute")]
    public int maxHealth;
    public int healthPoint;
    public int score;
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
        healthPoint = maxHealth;
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

        if (isJump)
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPos, 10 * Time.deltaTime);
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
        print("charging");
    }
    public void Jump()
    {
        print("jump");
        aimLoc = target.transform.localPosition;
        worldPos = transform.localToWorldMatrix.MultiplyPoint3x4(aimLoc);
        isJump = true;
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

}
