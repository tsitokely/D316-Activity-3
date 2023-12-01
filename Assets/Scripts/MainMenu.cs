using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fonction pour lancer le jeu
    public void playGame()
    {
        // Lancer la scène du premier niveau du jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Fonction pour quitter le jeu
    public void quitGame()
    {
        Application.Quit();
    }
}
