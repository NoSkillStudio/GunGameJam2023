using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private GameObject detectedPlayer;
    private void Start()
	{
		
	}

	private void Update()
	{
        Debug.DrawRay(transform.position + Vector3.right / 4f, transform.right, Color.green);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + Vector3.right / 4f, transform.right, rayDistance);

        if (rightHit.collider == detectedPlayer)
        {
            Debug.Log(detectedPlayer.name + " is found!");
        }
    }
}