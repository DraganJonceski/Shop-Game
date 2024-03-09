using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
       // SceneManager.UnloadSceneAsync("Menu");
    }

    public void GotoMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
   
}
