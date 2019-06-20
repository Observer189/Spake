using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeNotifier : MonoBehaviour
{
    // Start is called before the first frame update
    public String sceneName;
    private GameController gameController;
    void Awake()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameController.OnSceneChange(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
