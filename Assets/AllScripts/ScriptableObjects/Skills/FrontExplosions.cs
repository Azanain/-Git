using System.Collections;
using UnityEngine;
[CreateAssetMenu]
public class FrontExplosions : Ability
{
    private Coroutine _routine;
    private int _numberExplosions;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxSizeSphere;
    [SerializeField] private float _delayExplosion;
    public override void Activate()
    {
        base.Activate();
        CheckLevel();
        _routine = Coroutines.StartRoutine(DelayFire());
    }
    private IEnumerator DelayFire()
    {
        Vector3 transformPlayer = playerBody.systemInputCharacter.PositionLookAt; 
        float z = 5;

        for (int i = 0; i < _numberExplosions; i++)
        {
            Vector3 position = new Vector3(transformPlayer.x, transformPlayer.y, transformPlayer.z + z);
            GameObject expl = Instantiate(_explosion, position, playerBody.transform.rotation);
            var explosion = expl.GetComponent<Explosion>();
            explosion.StartExplosion(_tagTarget, _damage, duration, _maxSizeSphere);
            z++;
            yield return new WaitForSeconds(_delayExplosion);
        }
    }
    public override void CheckLevel()
    {
        switch (levelAbility)
        {
            case 0:
                _numberExplosions = 2;
                break;
            case 1:
                _numberExplosions = 3;
                break;
            case 2:
                _numberExplosions = 4;
                break;
            case 3:
                _numberExplosions = 5;
                break;
            case 4:
                _numberExplosions = 6;
                break;
        }
    }
}
