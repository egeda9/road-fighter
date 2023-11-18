using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isPaused;

    void Update()
    {
        // Check for input to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        // Check for input to exit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void TogglePause()
    {
        // Toggle the pause state
        this._isPaused = !this._isPaused;

        // Set the time scale to 0 when paused, 1 when not paused
        Time.timeScale = this._isPaused ? 0 : 1;
        
        SaveScript.IsGamePaused = this._isPaused;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}