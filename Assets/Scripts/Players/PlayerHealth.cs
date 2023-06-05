using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private Image _healthBar;
    [SerializeField] private int _maxHealth;
	private int _health;
	private bool _alive = true;

	private bool can = false;
	private int oldHealth;

	[SerializeField] private UnityEvent OnDie;

    private void Start()
	{
		_health = _maxHealth;
		oldHealth = _health--;
	}

	private IEnumerator ChangeValue(int oldHealth, float time)
	{
		float a = ((float) oldHealth / (float) _maxHealth);
		float b = ((float) _health / (float) _maxHealth);

		for (float t = 0f; t < time; t += 0.01f)
		{
			_healthBar.fillAmount = Mathf.Lerp(a, b, t);
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void ApplyDamage(int damageValue)
	{
			oldHealth = _health;
		_health -= damageValue;
		StartCoroutine(ChangeValue(oldHealth, 0.1f));
		if (_alive && _health <= -1)
		{
			Die();
		}
	}

	public void Die()
	{
		OnDie.Invoke();
		_alive = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
