using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected float speed;
    public static float speedMultiplier = 1;
    protected int exp;
    protected int lootAmmount;

    protected GameManager.EnemyTypes enemyType;
    public int Exp { get => exp; }
    public GameManager.EnemyTypes EnemyType { get => enemyType; }
    public int LootAmmount { get => lootAmmount; }

    public abstract void DropMaterial();
    public abstract void Move();
    public abstract void Die();
    public abstract void OnMouseEnter();
    public abstract void OnMouseDown();

    public void OnHouseTouch()
    {
        Destroy(this.gameObject); //TODO: if we use object pooling, remember to change here too.
    }
}
