using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firstflag;
    [SerializeField] private GameObject secondflag;
    [SerializeField] private GameObject firstflagstand;
    [SerializeField] private GameObject secondflagstand;
    private Transform player_1;
    private Transform player_2;

    [SerializeField] private Vector2 offset;

    private void Start()
    {
        player_1 = FindObjectOfType<Player_1_Collision>().transform;
        player_2 = FindObjectOfType<Player_2_Collision>().transform;
        //Spawn();
    }

    public void Spawn()
    {
        print("Spawn");
        Vector2 player_1_pos = player_1.position;
        Vector2 player_2_pos = player_2.position;

        // First flag
        Instantiate(firstflag, player_1_pos, Quaternion.identity);
        Instantiate(firstflagstand, player_1_pos - offset, Quaternion.identity);
        // Second flag
        Instantiate(secondflag, player_2_pos, Quaternion.identity);
        Instantiate(secondflagstand, player_2_pos - offset, Quaternion.identity);
    }
}
