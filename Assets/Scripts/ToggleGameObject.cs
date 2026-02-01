using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public void EnableObject()
    {
        if (target != null)
            target.SetActive(true);
    }

    public void DisableObject()
    {
        if (target != null)
            target.SetActive(false);
    }

    public void ToggleObject()
    {
        if (target != null)
            target.SetActive(!target.activeSelf);
    }
}
