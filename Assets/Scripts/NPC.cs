using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public enum MaskType
    {
        MaskOn,
        MaskOff
    }
    public enum MovementDirection
    {
        LeftToRight,
        RightToLeft,
        TopToBottom
    }

    [Header("Movement")]
    [SerializeField] private MovementDirection direction;
    private float speed = 1.25f;
    private Vector2 moveVector;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool move = true;

    [Header("Type")]
    [SerializeField] private MaskType maskType = MaskType.MaskOn;
    public MaskType Type => maskType;
    public bool wasClicked = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ApplyDirection();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        wasClicked = true;
        NPC_Events.RaiseNpcClicked(this);
        Debug.Log($"NPC clicked: {gameObject.name}", this);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (!move) return;

        transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
    }

    private void ApplyDirection()
    {
        switch (direction)
        {
            case MovementDirection.LeftToRight:
                moveVector = Vector2.right;
                spriteRenderer.flipX = false; // face right
                break;

            case MovementDirection.RightToLeft:
                moveVector = Vector2.left;
                spriteRenderer.flipX = true; // face left
                break;

            case MovementDirection.TopToBottom:
                moveVector = Vector2.down;
                // no flipX change here unless your art needs it
                break;
        }
    }
}
