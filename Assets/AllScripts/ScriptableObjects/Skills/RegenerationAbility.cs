using System.Collections;
using UnityEngine;
[CreateAssetMenu]
public class RegenerationAbility : Ability
{
    private Coroutine _routine;
    private float _percentHp;
    public override void Activate()
    {
        base.Activate();
        CheckLevel();
        _routine = Coroutines.StartRoutine(TimerAbility());
    }

    private IEnumerator TimerAbility()
    {
        float timer = 0;
        float hp = _percentHp * playerBody.playerHealth.MaxHp / 100;

        while (timer < duration)
        {
            playerBody.playerHealth.TakeDamage(-hp);
            yield return new WaitForSeconds(1);
        }
        while (timer >= duration)
            _routine = Coroutines.StartRoutine(TimerAbility());
    }
    public override void CheckLevel()
    {
        switch (levelAbility)
        {
            case 0:
                _percentHp = 3;
                break;
            case 1:
                _percentHp = 4;
                break;
            case 2:
                _percentHp = 5;
                break;
            case 3:
                _percentHp = 6;
                break;
            case 4:
                _percentHp = 7;
                break;
        }
    }
}

