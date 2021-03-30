using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    private static int score;
    private static int wood;
    private static int rock;
    private static int water;
    private static int crystal;

    public static int Score { get => score; set => score = value; }
    public static int Wood { get => wood; set => wood = value; }
    public static int Rock { get => rock; set => rock = value; }
    public static int Water { get => water; set => water = value; }
    public static int Crystal { get => crystal; set => crystal = value; }
}
