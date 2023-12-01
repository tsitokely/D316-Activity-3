using System.Collections;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        // d�sactiver la boite de dialogue au d�part
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // afficher la boite de dialogue si le bouton space est appuy� et le joueur est pr�s des panneaux
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            // Si la boite de dialogue est active tant que le joueur appuie sur space, fermez-l�
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else // sinon, affichez-l�
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                // Lancer une coroutine pour fermer la boite de dialogue apr�s 5 secondes sans action de l'utilisateur
                StartCoroutine(DeactivateAfterSeconds(5));
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

    // Coroutine pour d�sactiver la boite de dialogue apr�s quelques secondes
    IEnumerator DeactivateAfterSeconds(float seconds)
    {
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        // Deactivate the GameObject
        dialogBox.SetActive(false);
    }
}
