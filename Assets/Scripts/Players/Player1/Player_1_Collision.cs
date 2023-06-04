using UnityEngine;

public class Player_1_Collision : PlayerCollision, IPLayer_1
{
	private SpriteRenderer spriteRenderer;
    private bool isFlagGrabbed = false;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        
        if (collision.gameObject.TryGetComponent(out Finish finish))
            Destroy(finish.gameObject);

        if (!isFlagGrabbed && collision.gameObject.TryGetComponent(out Flag flag))
        {
            print("Player1");
            print(flag.owner);
            if (flag.owner != 1)
            {
                print("Player 1 grabs the flag!");
                flag.Grab();
                isFlagGrabbed = true;
            }
        }

        if (isFlagGrabbed && collision.gameObject.TryGetComponent(out FlagStand stand))
        {
            print(stand.owner);
            if (stand.owner == 1)
            {
                print("Player 1 wins!");
                // do restart
            }
        }
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
