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
            Debug.Log("Управление не назначено");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputInfo.getGasInfo() == 1)
        {
            movementVector.Set(-Mathf.Sin(Mathf.Deg2Rad * body.rotation),
                Mathf.Cos(Mathf.Deg2Rad * body.rotation)); //выставление нормального вектора движения
            
        }
        else if (inputInfo.getGasInfo() == 0) 
        {
            movementVector.Set(0,0);
        }
    }

    void FixedUpdate()
    {
        if (inputInfo.getTurnInfo() == 1)
        {
            body.angularVelocity = angularVelocity;
        }
        else if (inputInfo.getTurnInfo() == -1)
        {
            body.angularVelocity = -angularVelocity;
        }
        else if(inputInfo.getTurnInfo()==0)
        {
            body.angularVelocity = 0;
        }
        
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
}
