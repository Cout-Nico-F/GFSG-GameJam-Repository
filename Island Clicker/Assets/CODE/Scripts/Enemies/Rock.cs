using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Enemy
{
    public Rock()
    {
        this.exp = 65;
        this.health = 180;
        this.speed = 120f * speedMultiplier;
        this.lootAmmount = 1;
        this.enemyType = GameManager.EnemyTypes.Rock;
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

        string[] audioNames = { "RockDeath1", "RockDeath2", "RockDeath3", "RockDeath4" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

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

        string[] audioNames = { "RockHit1", "RockHit2", "RockHit3", "RockHit4" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
