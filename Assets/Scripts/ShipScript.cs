using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    private Rigidbody2D body;
    private BattleInputInfo inputInfo;
    private Vector2 movementVector;

    public float enginePower;
    public float angularVelocity;
    public float maxSpeed;
    
    private int rotation;
    private float Angle;
    [HideInInspector]
    public bool isTurning;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movementVector=new Vector2();

       
        
        if (GetComponent<PlayerControl>() != null)
        {
            inputInfo = GetComponent<PlayerControl>().getInputInfo();
        }
        /*else if (GetComponent<AIControl>()!=null)
        {
            inputInfo = GetComponent<AIControl>().getInputInfo();
        }*/
        else
        {
            Debug.LogError("Управление не назначено");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (inputInfo.GasInfo == 1)
            movementVector.Set(-Mathf.Sin(Mathf.Deg2Rad * body.rotation),
                Mathf.Cos(Mathf.Deg2Rad * body.rotation)); //выставление нормального вектора движения
        else if (inputInfo.GasInfo == 0)
            movementVector.Set(0,0);*/
        
        Angle = inputInfo.Angle;
        CalcRot(Angle,transform.eulerAngles.z);
    }

    void FixedUpdate()
    {
        /*if (inputInfo.TurnInfo == 1)
        {
            body.angularVelocity = angularVelocity;
        }
        else if (inputInfo.TurnInfo == -1)
        {
            body.angularVelocity = -angularVelocity;
        }
        else if(inputInfo.TurnInfo==0)
        {
            body.angularVelocity = 0;
        }*/
        
        Turn(Angle);
        
        
        if (inputInfo.GasInfo == 1)
            body.AddForce(new Vector2(movementVector.x * enginePower,
                movementVector.y * enginePower)); //приложение силы по векторы движения
        
        
        if (body.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            var velocity = body.velocity;
            Vector2 newVelocity = (velocity / velocity.magnitude) * maxSpeed; //Ограничение максимальной скорости
            velocity = newVelocity;
            body.velocity = velocity;
        }
    }
    
    void Turn(float Angle)
    {
        if (Angle - 2 < transform.eulerAngles.z && Angle + 2 > transform.eulerAngles.z)
        {
            isTurning = false;
            body.angularVelocity = 0;
            movementVector.Set(-Mathf.Sin(Mathf.Deg2Rad * body.rotation),
                Mathf.Cos(Mathf.Deg2Rad * body.rotation));
        }
        else
        {
            isTurning = true;
            if (rotation > 0)
            {
                body.angularVelocity = angularVelocity;
            }
            else if (rotation < 0)
            {
                body.angularVelocity = -angularVelocity;
            }

            movementVector.Set(0, 0);
        }
    }
    
    void CalcRot(float angle, float rot)
    {
        var externalArcLength = Math.Abs(angle - rot);
        var internalArcLength = 360 - externalArcLength;

        if (angle > rot)
        {
            if (internalArcLength > externalArcLength)
            {
                if (rot == 360)
                    transform.eulerAngles.Set(0, 0, 0);
                var eulerAngles = transform.eulerAngles;
                eulerAngles.Set(0, 0, eulerAngles.z + 3f);
                rotation = 1;
                //Debug.Log("Turn +");
            }
            else if (internalArcLength < externalArcLength)
            {
                if (rot == 0)
                    transform.eulerAngles.Set(0, 0, 360);
                var eulerAngles = transform.eulerAngles;
                eulerAngles.Set(0, 0, eulerAngles.z - 3f);
                rotation = -1;
                //Debug.Log("Turn -");
            }
        }
        else if (angle < rot)
        {
            if (internalArcLength < externalArcLength)
            {
                if (rot == 360)
                    transform.eulerAngles.Set(0, 0, 0);
                transform.eulerAngles.Set(0, 0, 1);
                rotation = 1;
                //Debug.Log("Turn +");
            }
            else if (internalArcLength > externalArcLength)
            {
                if (rot == 0)
                    transform.eulerAngles.Set(0, 0, 360);
                transform.eulerAngles.Set(0, 0, 359);
                rotation = -1;
                //Debug.Log("Turn -");
            }
        }
    }
}
