using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [Range(1, 2)]
    public int owner;

    public void Grab()
    {
        Transform player;
        if (owner == 1)
            player = FindObjectOfType<Player_2_Collision>().transform;
        else
            player = FindObjectOfType<Player_1_Collision>().transform;

        transform.SetParent(player, true);
        transform.localPosition = new Vector2(0f, 1.4f);
    }
}
