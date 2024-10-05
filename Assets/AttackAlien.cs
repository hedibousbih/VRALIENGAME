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
            // Récupérer l'Animator de l'alien
            Animator alienAnimator = other.GetComponent<Animator>();

            if (alienAnimator != null)
            {
                // Jouer l'animation de mort
                alienAnimator.Play("Alien@dead");

                // Facultatif : détruire ou désactiver l'alien après un délai
                StartCoroutine(DestroyAlien(other.gameObject));
            }
        }
    }

    // Coroutine pour détruire ou désactiver l'alien après un délai (si nécessaire)
    IEnumerator DestroyAlien(GameObject alien)
    {
        yield return new WaitForSeconds(2f); // Attendre 2 secondes après la mort
        Destroy(alien);  // Détruire l'alien, ou utiliser alien.SetActive(false); pour seulement le désactiver
    }
}
