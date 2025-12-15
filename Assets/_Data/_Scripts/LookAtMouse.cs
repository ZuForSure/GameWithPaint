using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] protected Vector3 mousePos, directionFromPlayer;
    public Vector3 DirectionFromPlayer => directionFromPlayer;

    void Update()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mousePos.z = 0;

        this.AimTarget(mousePos);
    }

    protected virtual void AimTarget(Vector3 target)
    {
        Vector3 diff = target - this.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        directionFromPlayer = target - transform.parent.position;
        directionFromPlayer.Normalize();
    }
}
