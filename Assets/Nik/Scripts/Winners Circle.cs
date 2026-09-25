using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private Transform player;
    [SerializeField] private Transform goal;
    private float winDistance = 7f;

    private bool hasWon = false;

    void Update()
    {
        if (hasWon)
        {
            return;
        }
        float distance = Vector2.Distance(player.position, goal.position);
        if (distance <= winDistance)
        {
            hasWon = true;
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
    }
}
