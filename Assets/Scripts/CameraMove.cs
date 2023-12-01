using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Bouger la caméra seulement à la fin par frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            // Créer un vecteur 3d qui a les coordonnées 2d du target et la valeur de l'axe z de la caméra
            Vector3 targetPosition = new Vector3(target.position.x,
                                                  target.position.y,
                                                  transform.position.z);
            // Limiter la vue de la caméra par les bordures de la scène
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                minPosition.y,
                                maxPosition.y);
            // Faire une interpolation linéaire pour bouger la caméra par rapport à la position du joueur
            transform.position = Vector3.Lerp(transform.position,
                                                targetPosition,
                                                smoothing);
        }
        
    }
}
