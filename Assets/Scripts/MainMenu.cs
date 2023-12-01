using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fonction pour lancer le jeu
    public void playGame()
    {
        // S'il y a une instance de GameManager, remettre à null toutes les variables 
       if (GameManager.Instance != null)
        {
            GameManager.Instance.NextSpawnPosition = null;
            GameManager.Instance.hasSword = false;
            GameManager.Instance.hasShield = false;
        }

        // Lancer la scène du premier niveau du jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Fonction pour quitter le jeu
    public void quitGame()
    {
        Application.Quit();
    }
}
