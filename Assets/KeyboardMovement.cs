using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Vitesse de mouvement
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
        {
            Debug.LogError("Le composant CharacterController est manquant sur l'objet.");
        }
    }

    void Update()
    {
        // Récupère les entrées du clavier
        float moveX = Input.GetAxis("Horizontal"); // Flèches gauche/droite ou touches A/D
        float moveZ = Input.GetAxis("Vertical"); // Flèches haut/bas ou touches W/S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Appliquer le mouvement
        if (characterController != null)
        {
            characterController.Move(move * moveSpeed * Time.deltaTime);
        }
    }
}
