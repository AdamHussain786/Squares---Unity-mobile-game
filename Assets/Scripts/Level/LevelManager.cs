using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameMaster gm;
    [HideInInspector]
    public int currentSceneIndex;
    // called zero
    void Awake()
    {
        gm = GetComponent<GameMaster>();
    }

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);

        // Instantiate a player
        if(gm != null)
        {
            gm.SpawnPlayer();
            gm.coinCache = 0;
        }

        GetCurrentSceneIndex();

        if(currentSceneIndex == 0)
        {
            if(gm!= null)
            {
                gm.SearchForMenuElements();
            }
        }
            
        
    }

    // called when the game is terminated
    void OnDisable()
    {  
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        OnSceneLoaded(SceneManager.GetSceneByBuildIndex(level), LoadSceneMode.Single);
    }



    public void NextLevel()
    {
        //Getting next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
           
            SceneManager.LoadScene(nextSceneIndex);

            OnSceneLoaded(SceneManager.GetSceneByBuildIndex(nextSceneIndex), LoadSceneMode.Single);
        }
        else
        {
            //Go back to main menu
            LoadLevel(0);
        }
        //When the scene is loaded then we want to do some more logic.

    }

    public void GetCurrentSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    public void RestartCurrentScene()
    {
        GetCurrentSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Click()
    {
        AudioManager.instance.PlaySound("Click");
    }

}
