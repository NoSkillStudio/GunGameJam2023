using UnityEngine;

public class Player_2_Collision : PlayerCollision, IPlayer_2
{
    private SpriteRenderer spriteRenderer;
    private bool isFlagGrabbed = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

        if (collision.gameObject.TryGetComponent(out Finish finish))
            Destroy(finish.gameObject);

        if (collision.gameObject.TryGetComponent(out Flag flag))
        {
            if (flag.owner != 2)
            {
                print("Player 2 grabs the flag!");
                flag.Grab();
                isFlagGrabbed = true;
            }
        }

        if (isFlagGrabbed && collision.gameObject.TryGetComponent(out FlagStand stand))
        {
            if (stand.owner == 2)
            {
                print("Player 2 wins!");
                // do restart
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_2 disappearanceZone_2))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
