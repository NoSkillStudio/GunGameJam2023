using UnityEngine;
using UnityEngine.Events;

public class Player_1_Collision : PlayerCollision, IPLayer_1
{
	private SpriteRenderer spriteRenderer;
    private bool isFlagGrabbed = false;

    [SerializeField] private UnityEvent OnWin;
    [SerializeField] private UnityEvent OnGarabFlag;

    [SerializeField] private UnityEvent OnFinishWin;

    private void Start()
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.TryGetComponent(out DisappearanceZone_1 disappearanceZone_1))
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        
        if (collision.gameObject.TryGetComponent(out Finish finish))
        {
            OnFinishWin.Invoke();

            Destroy(finish.gameObject);
        }


        if (!isFlagGrabbed && collision.gameObject.TryGetComponent(out Flag flag))
        {
            print("Player1");
            print(flag.owner);
            if (flag.owner != 1)
            {
                //print("Player 1 grabs the flag!");
                OnGarabFlag.Invoke();
                flag.Grab();
                isFlagGrabbed = true;
            }
        }

        if (isFlagGrabbed && collision.gameObject.TryGetComponent(out FlagStand stand))
        {
            print(stand.owner);
            if (stand.owner == 1)
            {
                //print("Player 1 wins!");
                OnWin.Invoke();
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
