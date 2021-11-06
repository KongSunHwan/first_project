using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMnuw : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    
    }
    public void OnClickNewGame()
    {
        Application.LoadLevel(0);
        Time.timeScale = 0;
    }

}
