using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTrigger : MonoBehaviour
{
    [SerializeField] private string exitTag = "Exit";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(exitTag))
        {
            // Destroy the whole NPC (parent), not just the trigger child
            Destroy(transform.root.gameObject);
            Debug.Log("NPC bye bye");
        }
    }
}
