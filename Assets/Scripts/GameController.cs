using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ship;

    private new GameObject camera;

    private CameraScript cameraScript;

    public static bool isExist=false;




    private void Awake()
    {
        if (!isExist)
        {
            DontDestroyOnLoad(gameObject);
            isExist = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSceneChange(String sceneName)
    {
        if (sceneName.Equals("NotNet"))
        {
            Debug.Log("Change");
            camera = GameObject.FindWithTag("MainCamera");
            cameraScript = camera.GetComponent<CameraScript>();
        
        
            GameObject tempShip=Instantiate(ship, new Vector3(0, 0, 0), Quaternion.identity);
            tempShip.AddComponent<PlayerControl>();
            tempShip.AddComponent<ShipScript>();
            ShipScript shipScript = tempShip.GetComponent<ShipScript>();
            shipScript.angularVelocity = 180;
            shipScript.enginePower = 2000;
            shipScript.maxSpeed = 40;
            Debug.Log(cameraScript.transform.position);
            cameraScript.setPlayer(tempShip.transform);
        }
    }
}
