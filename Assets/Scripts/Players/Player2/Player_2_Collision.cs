using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Collision : MonoBehaviour, IPlayer_2
{
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}