using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
// method for levelLoading
    public void LevelLoader() 
    {
        int i = SceneManager.GetActiveScene().buildIndex; // will get the actvie scene index and call it 'i'
        SceneManager.LoadScene(i + 1); // will loadNext Scene
    }
    // a method to Exit the game
    public void ExitGame()
    {
        Application.Quit(); // will quit game 
        Debug.Log("Game Closed"); //debug
    }
    //method for retry button after losin
    public void Retry()
    {
        if (SceneManager.GetActiveScene().name == "LoseScreen 1") // if lostscene is 1
        {
            SceneManager.LoadScene("Level1"); // will load level1
        }
        if (SceneManager.GetActiveScene().name == "LoseScreen 2")// if lostscene is 2
        {
            SceneManager.LoadScene("Level2");// will load level2
        }
        if (SceneManager.GetActiveScene().name == "LoseScreen 3")// if lostscene is 3
        {
            SceneManager.LoadScene("Level3");// will load level3
        }
        if (SceneManager.GetActiveScene().name == "LoseScreen 4")// if lostscene is 4
        {
            SceneManager.LoadScene("LevelDor");// will load leveldor
        }
    }
    // methop for a return to menu button
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // returns to main menu
    }
}
