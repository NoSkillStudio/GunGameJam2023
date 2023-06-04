using UnityEngine;

public class SwapperPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player_1;
    [SerializeField] private GameObject player_2;
    [SerializeField] private PlayerControlls playerControlls_1;
    [SerializeField] private PlayerControlls playerControlls_2;
    private Vector3 buffer;

    public void SwapPlayers()
    {
        buffer = player_1.transform.position;
        player_1.transform.position = player_2.transform.position;
        playerControlls_1.SetPosition(player_1.transform);
        player_2.transform.position = buffer;
        playerControlls_2.SetPosition(player_2.transform);

    }
}