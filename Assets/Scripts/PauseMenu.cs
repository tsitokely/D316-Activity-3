using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Référencer le gameobject PauseMenu
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Appuyer sur la touche esc pour lancer le menu
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isPaused)
            {
                // Si le menu pause est en cours, résumer le jeu
                ResumeGame();
            }
            else
            {
                // Lancer le menu pause
                PauseGame();
            }
        }
    }
    public void ResumeGame() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    // Fonction pour pauser le jeu
    public void PauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Fonction pour revenir vers le menu principal
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("main_menu");
    }

    // Fonction pour quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}
