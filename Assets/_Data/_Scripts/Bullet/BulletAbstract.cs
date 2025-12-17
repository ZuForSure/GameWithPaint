using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    [Header("Bullet Abstract")]
    public Bullet bullet;
    public Player player;

    private void Reset()
    {
        this.LoadBullet();
        this.LoadPlayer();
    }

    protected void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponentInParent<Bullet>();
    }

    protected void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }
}
