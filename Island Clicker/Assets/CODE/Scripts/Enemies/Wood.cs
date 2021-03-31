using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Enemy
{
    public Wood()
    {
        this.exp = 25;
        this.health = 60;
        this.speed = 120f * speedMultiplier;
        this.lootAmmount = 4;
        this.enemyType = GameManager.EnemyTypes.Wood;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void DropMaterial()
    {
        
    }

    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, StaticReference.Target.position, speed * Time.deltaTime);
    }

    public override void Die()
    {
        //tell the game manager that you died.
        StaticReference.GameManager.EnemyDied(this);
        Destroy(this.gameObject); //TODO: could apply object pooling technique if we have time
    }

    public override void OnMouseEnter()
    {
        if (StaticReference.Sword.Damage > this.health)
        {
            Die();
        }
    }

    public override void OnMouseDown()
    {
        health -= StaticReference.Sword.Damage;
        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
