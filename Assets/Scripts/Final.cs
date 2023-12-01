using TMPro;
using UnityEngine;

public class Final : MonoBehaviour
{
    public bool hasSword;
    public bool hasShield;
    public bool playerInRange;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public string dialog2;

    // Start is called before the first frame update
    void Start()
    {
        // désactiver la boite de dialogue au départ
        dialogBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // afficher la boite de dialogue si le bouton space est appuyé et le joueur est près des panneaux
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            // Si la boite de dialogue est active tant que le joueur appuie sur space, fermez-là
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else if (GameManager.Instance.hasSword && GameManager.Instance.hasShield)// sinon, affichez-là
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                // Lancer une fonction pour fermer la boite de dialogue après 10 secondes sans action de l'utilisateur et pour fermer le jeu
                Invoke("CloseDialogBox", 10);
                Invoke("QuitGame", 10);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog2;
                // Lancer une fonction pour fermer la boite de dialogue après 1 secondes sans action de l'utilisateur
                Invoke("CloseDialogBox", 1);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Coroutine pour désactiver la boite de dialogue après quelques secondes
    void CloseDialogBox()
    {
        dialogBox.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
