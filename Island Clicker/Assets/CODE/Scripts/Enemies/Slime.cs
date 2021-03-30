using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField]
    private Sword sword; //applied to the prefab on editor.
    public Slime()
    {
        this.exp = 17;
        this.health = 30;
        this.speed = 1;
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
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public override void Die()
    {
        Destroy(this.gameObject); //TODO: could apply object pooling technique if we have time
    }

    public override void OnMouseEnter()
    {
        if (sword.Damage > this.health)
        {
            Die();
        }
    }

    public override void OnMouseDown()
    {
        health -= sword.Damage;
        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
