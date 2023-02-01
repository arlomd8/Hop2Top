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

    [Header("Target Attribute")]
    public Vector2 targetVector;
    public bool isHolding;

    private void Start()
    {
        healthPoint = maxHealth;
    }

    private void Update()
    {
        if (isHolding) 
        { 
            target.transform.localPosition += new Vector3(0, 2 * Time.deltaTime); 
        }

        else
        {
            ResetTarget();
        }
        
    }
    public void Charging()
    {
        print("charging");
    }
    public void Jump()
    {
        print("jump to target");
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
