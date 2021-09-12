using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void GoToLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void GoToPlayLevel()
    {
        SceneManager.LoadScene("Play Level");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadNextLevel() //We use this to move between the two indexes between levels.
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 2);
            //Need to add 2 to go from active level to next level since game over scene is between levels.   
    }

    public void ReplayPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void GameOverSceneForEachLevel() //This is the same code as "LoadNextScene" but I wanted to specify.
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
            //Need to add 1 to go from active scene to next. 
    }

    public void LoadStartScene() //We use this to go back to the start.
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - currentSceneIndex); //This way, we take active scene minus active scene so index is zero.

        FindObjectOfType<GameSession>().resetGame();
    }

    public void QuitGame() //We use this to quit.
    {
        Application.Quit();
    }

    public void ExitGameViaEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
      
}
