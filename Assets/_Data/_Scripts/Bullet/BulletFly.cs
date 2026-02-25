using UnityEngine;

public class BulletFly : BulletAbstract
{
    public void GetDictionForFlying()
    {
        this.bullet.flyDirection = this.player.PlayerShooting.ShootDirection;
        this.Flying();
    }

    protected void Flying()
    {
        this.bullet.bulletRB.velocity = this.bullet.FlySpeed * this.bullet.flyDirection;
    }
}
