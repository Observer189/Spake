using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Transform transform;
    Transform playerTrans;

    void Start()
    {

        //player = GameObject.FindWithTag("Player");
        transform = GetComponent<Transform>();
        //playerTrans = player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrans != null)
        {
            var position = playerTrans.position;
            transform.position = new Vector3(position.x, position.y, -10);
        }
    }

    public void setPlayer(Transform plTrans)
    {
        playerTrans = plTrans;
    }

}
