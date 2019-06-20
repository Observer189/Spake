using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private BattleInputInfo inputInfo;
    // Start is called before the first frame update
    private void Awake()
    {
        inputInfo=new BattleInputInfo();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) inputInfo.setIsShooting(true);
        if (Input.GetKeyUp(KeyCode.Space)) inputInfo.setIsShooting(false);
        
        if (Input.GetAxis("Horizontal") < 0) 
        
        {
            inputInfo.setTurnInfo(1);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            inputInfo.setTurnInfo(-1);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            inputInfo.setTurnInfo(0);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            inputInfo.setGasInfo(1);
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            inputInfo.setGasInfo(0);
        }
    }

    public BattleInputInfo getInputInfo()
    {
        return inputInfo;
    }
}
