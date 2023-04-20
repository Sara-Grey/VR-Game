using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public int Garden;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(Garden);
    }
    public void Exit() 
    {
        Application.Quit();    
    }
}
