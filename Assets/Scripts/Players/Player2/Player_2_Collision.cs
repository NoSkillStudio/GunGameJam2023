using UnityEngine;

public class Player_2_Collision : PlayerCollision, IPlayer_2
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
