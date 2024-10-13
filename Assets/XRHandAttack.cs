using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRHandAttack : MonoBehaviour
{
    public string alienTag = "Alien";  // Tag pour identifier les aliens

    // Méthode déclenchée lorsque les mains ou l'objet entrent en collision avec un alien
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet avec lequel on entre en contact a le tag "Alien"
        if (other.CompareTag(alienTag))
        {
            Debug.Log("Collision avec l'alien : " + other.name); // Vérifie si la collision est détectée

            // Récupérer l'Animator de l'alien
            Animator alienAnimator = other.GetComponent<Animator>();

            if (alienAnimator != null)
            {
                // Déclencher le trigger de mort
                alienAnimator.SetTrigger("Die"); // Remplace "Die" par le nom de ton trigger
                Debug.Log("Trigger de mort activé pour : " + other.name); // Vérifie si le trigger est activé
            }
            else
            {
                Debug.Log("Animator non trouvé pour : " + other.name); // Si l'Animator n'est pas trouvé
            }

            // Détruire l'alien après un délai
            StartCoroutine(DestroyAlien(other.gameObject));
        }
    }

    // Coroutine pour détruire l'alien après un délai
    IEnumerator DestroyAlien(GameObject alien)
    {
        yield return new WaitForSeconds(2f); // Attendre 2 secondes après la mort
        Destroy(alien);  // Détruire l'alien
        Debug.Log("Alien détruit : " + alien.name); // Vérifie si l'alien est détruit
    }
}
