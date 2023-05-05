using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StandartWeaphone : Weaphone
{
    protected override void GetBullet(Bullet bullet)
    {
        base.GetBullet(bullet);
        bullet.transform.rotation = Quaternion.AngleAxis(_playerInput.LookDirection, Vector3.forward);
        bullet.Move();
    }
}