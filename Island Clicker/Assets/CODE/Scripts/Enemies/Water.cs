﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Enemy
{
    public Water()
    {
        this.exp = 95;
        this.health = 540;
        this.speed = 120;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void DropMaterial()
    {
        throw new System.NotImplementedException();
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
