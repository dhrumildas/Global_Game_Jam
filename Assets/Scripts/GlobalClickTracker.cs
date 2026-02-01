using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalClickTracker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Optional: ignore clicks on UI
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            NPC_Events.RaiseTotalClicks();
        }
    }
}
