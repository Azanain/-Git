using System.Collections.Generic;
using UnityEngine;

public class DataUnits : MonoBehaviour
{
    private const string ENEMY_ID = "Enemy";
    private const string PLAYER_ID = "Player";
    private static int numberPlayer = 1;
    private static int numberEnemy = 1;

    private static Dictionary<string, Health> bodies = new Dictionary<string, Health>();

    public static void RegisterBody(Health health, bool isPlayer, string idbody)
    {
        string nameBody;
        if (isPlayer)
        {
            nameBody = $"{PLAYER_ID}_{numberPlayer}_{idbody}";
            numberPlayer++;
        }
        else
        {
            nameBody = $"{ENEMY_ID}_{numberEnemy}_{idbody}";
            numberEnemy++;
        }
        bodies.Add(nameBody, health);
        health.transform.name = nameBody;
    }
    public static void UnRegisterBody(string bodyID)
    {
        bodies.Remove(bodyID);
    }
    public static Health GetBody(string bodyID)
    {
        return bodies[bodyID];
    }
}
