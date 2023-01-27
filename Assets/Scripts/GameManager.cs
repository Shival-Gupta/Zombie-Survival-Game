using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string SplashScene = "Splash";
    public string HomeScene = "Home";
    public string LevelScene = "Level";
    
    void Awake()
    {
        Debug.Log("Initializing GameManager script");
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        Debug.Log("Loading Home Scene");
        SceneManager.LoadScene(HomeScene);
    }
}
