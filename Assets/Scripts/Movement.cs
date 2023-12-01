using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    private Animator animInit;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.NextSpawnPosition.HasValue)
        {
            // Donner comme position les coordonées sur la prochaine scène si le joueur est passé par un warp point
            transform.position = new Vector3(GameManager.Instance.NextSpawnPosition.Value.x, GameManager.Instance.NextSpawnPosition.Value.y, 0);
            animInit = this.gameObject.GetComponent<Animator>();
            if (this.gameObject.scene.name != "Islands")
            {
                animInit.SetFloat("Horizontal", 0);
                animInit.SetFloat("Vertical", 1);
            } 
            
        }
        else
        {
            // Donner une position de départ au personnage
            transform.position = new Vector3(-3, 4, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Update the animation in sync with the movement
            UpdateAnimation();
        }
    }

    void UpdateAnimation()
    {
        if (movement != Vector2.zero) {
            UpdateMovement();
            // Animation
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        } else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void UpdateMovement()
    {
        //if (PlayerSpawnManager.Instance != null)
        {
          //  transform.position = PlayerSpawnManager.Instance.Player.transform.position;
        }
        //else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
