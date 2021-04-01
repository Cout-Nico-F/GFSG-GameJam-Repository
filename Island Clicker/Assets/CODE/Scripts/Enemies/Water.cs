using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Enemy
{
    public Water()
    {
        this.exp = 95;
        this.health = 540;
        this.speed = 110 * speedMultiplier;
        this.lootAmmount = 10;
        this.enemyType = GameManager.EnemyTypes.Water;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Start()
    {
        int random = UnityEngine.Random.Range(1, 10);
        if (random > 6)
        {
            AudioManager.instance.Play("WaterLaugh1");
        }
    }

    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, StaticReference.Target.position, speed * Time.deltaTime);
    }

    public override void Die()
    {
        //tell the game manager that you died.
        StaticReference.GameManager.EnemyDied(this);

        string[] audioNames = { "WaterDeath1", "WaterDeath2", "WaterDeath3", "WaterDeath4" };
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

        string[] audioNames = { "WaterHit1", "WaterHit2", "WaterHit3", "WaterHit4" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
