using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected PlayerShooting playerShooting;
    public PlayerShooting PlayerShooting => playerShooting;

    private void Reset()
    {
        this.LoadPlayerShooting();
    }

    protected void LoadPlayerShooting()
    {
        if (this.playerShooting != null) return;
        this.playerShooting = GetComponentInChildren<PlayerShooting>();
    }
}
