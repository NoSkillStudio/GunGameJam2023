using UnityEngine;

public class Player_1_Collision : PlayerCollision, IPLayer_1
{
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
