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

    // Bouger la cam�ra seulement � la fin par frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            // Cr�er un vecteur 3d qui a les coordonn�es 2d du target et la valeur de l'axe z de la cam�ra
            Vector3 targetPosition = new Vector3(target.position.x,
                                                  target.position.y,
                                                  transform.position.z);
            // Limiter la vue de la cam�ra par les bordures de la sc�ne
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                minPosition.y,
                                maxPosition.y);
            // Faire une interpolation lin�aire pour bouger la cam�ra par rapport � la position du joueur
            transform.position = Vector3.Lerp(transform.position,
                                                targetPosition,
                                                smoothing);
        }
        
    }
}
