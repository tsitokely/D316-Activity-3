using TMPro;
using UnityEngine;

public class item : MonoBehaviour
{
    public bool hasSword;
    public bool hasShield;
    public bool playerInRange;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;

    void Start()
    {
        // désactiver la boite de dialogue au départ
        dialogBox.SetActive(false);

        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.hasSword && gameObject.name == "sword")
            {
                gameObject.SetActive(false);
            }

            if (GameManager.Instance.hasShield && gameObject.name == "shield")
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            hasSword = false;
            hasShield = false;
        }
        // désactiver la boite de dialogue au départ
        
    }

    void Update()
    {
        // prendre l'item si le bouton space est appuyé et le joueur est près
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (GameManager.Instance != null && gameObject.name == "sword")
            {
                hasSword = true;
                GameManager.Instance.hasSword = hasSword;
                gameObject.SetActive(false);
                // Si la boite de dialogue est active tant que le joueur appuie sur space, fermez-là
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else // sinon, affichez-là
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    Invoke("CloseDialogBox", 1);
                }
            }

            if (GameManager.Instance != null && gameObject.name == "shield")
            {
                hasShield = true;
                GameManager.Instance.hasShield = hasShield;
                gameObject.SetActive(false);
                // Si la boite de dialogue est active tant que le joueur appuie sur space, fermez-là
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else // sinon, affichez-là
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    Invoke("CloseDialogBox", 1);
                }
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

    void CloseDialogBox()
    {
        dialogBox.SetActive(false);
    }
}
