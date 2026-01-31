using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviour1 : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed = 2f; // units per second
    [SerializeField] private bool move = true;

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
    }

    private void OnMouseDown()
    {
        Debug.Log($"NPC clicked: {gameObject.name}", this);
    }

    private void Update()
    {
        if (!move) return;

        // Move to the right (+X)
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }
    }
}
