using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    public Bullet bullet;

    private void Reset()
    {
        this.LoadBullet();
    }

    protected void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponentInParent<Bullet>();
    }
}
