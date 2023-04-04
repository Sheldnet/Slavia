using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootNMove : MonoBehaviour
{
    public float tempACD, AttackCD, FinalDamage, FinalShootSpeed, FinalRange;
    public float MoveSpeed, Damage, DamageMul, FloatDamage, AttackSpeed, AttackSpeedMul, FloatAttackSpeed, ShootSpeed, ShootSpeedMul, Range, RangeMul;
    public GameObject Bullet;
    public Transform shotPoint;
    public Quaternion rotation;
    private Vector2 MoveInput;
    private Vector2 MoveVelocity;
    private Rigidbody2D rb;
    void Start() //Исходные статы
    {
        tempACD = 0;
        MoveSpeed = 5;
        rotation = Quaternion.Euler(0,0,0); //Направление пули
        rb = GetComponent<Rigidbody2D>();
        Damage = 1; //Урон
        DamageMul = 1;  //Множитель урона
        FloatDamage = 0; //Плоский урон
        AttackSpeed = 1; //Скорость атаки
        AttackSpeedMul = 1; //Множитель скорости атаки
        FloatAttackSpeed = 0; //Плоская скорость атаки
        ShootSpeed = 10; //Скорость полета пули
        ShootSpeedMul = 1; //Множитель скорости полета пули
        Range = 10; //Дальность атаки
        RangeMul = 1; //Множитель дальности атаки
    }

    void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Передвижение
        MoveVelocity = MoveInput.normalized * MoveSpeed;
        rb.MovePosition(rb.position + MoveVelocity * Time.deltaTime);
        AttackCD = 1/(AttackSpeed*AttackSpeedMul+FloatAttackSpeed); //Конечная скорость атаки
        FinalDamage = Damage*DamageMul+FloatDamage; //Конечный урон
        FinalShootSpeed = ShootSpeed*ShootSpeedMul; //Конечная скорость полета пули
        FinalRange = Range * RangeMul; //Конечная дальность атаки
        if (tempACD <= 0)
        {
            Shoot();
            tempACD = AttackCD;
        }
        else tempACD -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(Bullet, shotPoint.position, rotation);
    }
}
