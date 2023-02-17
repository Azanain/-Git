using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class FrontFireBoltAbility : Ability
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _damage;
    [SerializeField] float _maxSizeSphere;
    [SerializeField] private float _delayShootBolt;
    private int _numberBolt;
    private Coroutine _routine;
    public override void Activate()
    {
        base.Activate();
        CheckLevel();

       _routine = Coroutines.StartRoutine(DelayFire());
    }
    private IEnumerator DelayFire()
    {
        Vector3 transformPlayer = playerBody.systemInputCharacter.PositionLookAt;
        transformPlayer = new Vector3(transformPlayer.x, transformPlayer.y +1, transformPlayer.z);

        for (int i = 0; i < _numberBolt; i++)
        {
            Instantiate(_bullet, transformPlayer, playerBody.transform.rotation);
            yield return new WaitForSeconds(_delayShootBolt);
        }
        _routine = Coroutines.StartRoutine(DelayFire());
    }
    public override void CheckLevel()
    {
        switch (levelAbility)
        {
            case 0:
                _numberBolt = 2;
                break;
            case 1:
                _numberBolt = 3;
                break;
            case 2:
                _numberBolt = 4;
                break;
            case 3:
                _numberBolt = 5;
                break;
            case 4:
                _numberBolt = 6;
                break;
        }
    }
}
