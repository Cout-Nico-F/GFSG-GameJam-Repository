using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticReference
{
    private static Transform target;
    private static Sword sword;

    public static Transform Target { get => target; set => target = value; }
    public static Sword Sword { get => sword; set => sword = value; }
}
