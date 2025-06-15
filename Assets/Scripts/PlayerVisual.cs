using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    bool left = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector2 vector = PlayerController.Instance.VectorRunning();
        if (Mathf.Abs(vector.x) > 0)
        {
            if (vector.x < 0) { left = true; }
            else { left = false; }
        }
        Flip(left);
    }

    private void Flip(bool left)
    {
        if (left) { spriteRenderer.flipX = true; }
        else { spriteRenderer.flipX = false; }
    }
}
