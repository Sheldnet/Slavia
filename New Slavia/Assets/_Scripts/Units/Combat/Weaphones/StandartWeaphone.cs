using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StandartWeaphone : Weaphone
{
    protected override void GetBullet(Bullet bullet)
    {
        base.GetBullet(bullet);        
        Debug.Log(_playerInput.LookDirection);
        bullet.Move();
    }
}