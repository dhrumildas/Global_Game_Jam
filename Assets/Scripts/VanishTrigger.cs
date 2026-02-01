using UnityEngine;

public class VanishTrigger : MonoBehaviour
{
    [SerializeField] private string exitTag = "Exit";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(exitTag)) return;

        // Get NPC from parent/root safely
        NPC npc = GetComponentInParent<NPC>();
        if (npc != null && npc.wasClicked == false)
        {
            NPC_Events.RaiseNpcReachedExit(npc);
        }

        Destroy(transform.root.gameObject);
        Debug.Log("NPC has vanished upon reaching the exit.");
    }
}
