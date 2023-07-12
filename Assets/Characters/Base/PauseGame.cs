using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject BaseLevelWindow1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Adjust the input key according to your preference
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if(isPaused)
        {
            PauseGame();
        }
        else if(!isPaused)
        {
            ResumeGame();
        }


    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to freeze the game
        isPaused = true;
        // Add additional logic if needed, such as showing a pause menu
    }

    public void PauseGameLevelUp()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to freeze the game
        isPaused = true;
        BaseLevelWindow1.SetActive(true);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f; // Set the time scale back to 1 to resume the game
        isPaused = false;
        // Add additional logic if needed, such as hiding the pause menu
    }
}