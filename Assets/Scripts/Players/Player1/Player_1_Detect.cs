using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Detect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    private void Start()
	{
		
	}

	private void Update()
	{
        Debug.DrawRay(transform.position + Vector3.right / 4f, transform.right, Color.green);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + Vector3.right / 4f, transform.right, rayDistance);

        if (rightHit.collider == gameObject.TryGetComponent(out Player_2_Controls player_2_Controls)) Debug.Log("Second person is found!");
    }
}