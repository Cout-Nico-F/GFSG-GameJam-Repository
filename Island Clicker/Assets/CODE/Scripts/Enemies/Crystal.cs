using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    public Crystal()
    {
        this.exp = 150;
        this.health = 2160;
        this.speed = 100 * speedMultiplier;
        this.lootAmmount = 1;
        this.enemyType = GameManager.EnemyTypes.Crystal;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Start()
    {
        int random = UnityEngine.Random.Range(1, 10);
        if (random > 8)
        {
            AudioManager.instance.Play("CrystalLaugh1");
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

        string[] audioNames = { "CrystalDeath1", "CrystalDeath2", "CrystalDeath4", "CrystalDeath5" };
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

        string[] audioNames = { "CrystalHit1", "CrystalHit2", "CrystalHit4", "CrystalHit5" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
