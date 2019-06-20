using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ship;

    private new GameObject camera;

    private CameraScript cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        camera = GameObject.FindWithTag("MainCamera");
        cameraScript = camera.GetComponent<CameraScript>();
        
        
        GameObject tempShip=Instantiate(ship, new Vector3(0, 0, 0), Quaternion.identity);
        tempShip.AddComponent<PlayerControl>();
        tempShip.AddComponent<ShipScript>();
        ShipScript shipScript = tempShip.GetComponent<ShipScript>();
        shipScript.angularVelocity = 40;
        shipScript.enginePower = 500;
        shipScript.maxSpeed = 40;
        cameraScript.setPlayer(tempShip.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
