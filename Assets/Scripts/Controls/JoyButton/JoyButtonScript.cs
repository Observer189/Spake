using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class JoyButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public bool Pressed;

    public Image notPressed;

    private Vector2 standartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        standartPos = notPressed.transform.position;
        Debug.Log(standartPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        notPressed.transform.position = standartPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        notPressed.transform.position = standartPos*100;

        switch (gameObject.tag)
        {
            case "1stButton":
                Debug.Log("Loading");
                Debug.Log("QuitingScene");
                Application.Quit(); //здесь пытаюсь закрыть сцену   
                LoadGame("NetworkBattle");
                Debug.Log("Load!!");
                break;
            case "2ndButton":
                Debug.Log("Loading");
                Debug.Log("QuitingScene");
                Application.Quit(); //здесь пытаюсь закрыть сцену   
                LoadGame("NetworkBattleWithAI");
                Debug.Log("Load!!");
                break;
            case "3rdButton":
                Debug.Log("Loading");
                Debug.Log("QuitingScene");
                Application.Quit(); //здесь пытаюсь закрыть сцену   
                LoadGame("NOTNetworkBattle");
                Debug.Log("Load!!");
                break;
        }
        
        void LoadGame(String sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
