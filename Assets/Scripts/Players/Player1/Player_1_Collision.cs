using UnityEngine;

public class Player_1_Collision : PlayerCollision, IPLayer_1
{
	private SpriteRenderer spriteRenderer;

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
            print("Player 1 wins");
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
