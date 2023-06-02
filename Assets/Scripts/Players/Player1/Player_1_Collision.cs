using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Collision : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
    }
}