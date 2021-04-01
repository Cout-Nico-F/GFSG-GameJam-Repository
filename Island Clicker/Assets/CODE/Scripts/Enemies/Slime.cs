using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Slime()
    {
        this.exp = 17;
        this.health = 30;
        this.speed = 160 * speedMultiplier;
        this.enemyType = GameManager.EnemyTypes.Slime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Start()
    {
        int random = UnityEngine.Random.Range(1, 10);
        if (random > 7)
        {
            AudioManager.instance.Play("SlimeLaugh1");
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

        string[] audioNames = { "SlimeDeath1", "SlimeDeath2", "SlimeDeath3", "SlimeDeath4" };
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

        string[] audioNames = { "SlimeHit1", "SlimeHit2", "SlimeHit3", "SlimeHit4", "SlimeHit5" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

        if (health <= 0)
        {
            Die();
        }
        //trigger animations and sound?
    }
}
