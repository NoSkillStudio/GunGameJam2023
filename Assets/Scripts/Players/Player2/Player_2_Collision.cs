using UnityEngine;

public class Player_2_Collision : PlayerCollision, IPlayer_2
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

        if (collision.gameObject.TryGetComponent(out Finish finish))
            Destroy(finish.gameObject);
            print("Player 2 wins");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
