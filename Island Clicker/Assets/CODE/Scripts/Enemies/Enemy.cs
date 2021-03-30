using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected float speed;
    protected int exp;
    public int Exp { get => exp; }

    public abstract void DropMaterial();
    public abstract void Move();
    public abstract void Die();
    public abstract void OnMouseEnter();
    public abstract void OnMouseDown();
}
