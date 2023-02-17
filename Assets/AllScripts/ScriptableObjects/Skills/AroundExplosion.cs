using UnityEngine;
[CreateAssetMenu]
public class AroundExplosion : Ability
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _maxSizeSphere;

    private float _damage;
    public override void Activate()
    {
        GameObject prefabExplosion = Instantiate(_explosion, playerBody.transform.position, Quaternion.identity);
        Explosion explosion = prefabExplosion.GetComponent<Explosion>();
        explosion.StartExplosion(_tagTarget, _damage, duration, _maxSizeSphere);
    }

    public override void CheckLevel()
    {
        switch (levelAbility)
        {
            case 0:
                _damage = 15;
                break;
            case 1:
                _damage = 20;
                break;
            case 2:
                _damage = 25;
                break;
            case 3:
                _damage = 30;
                break;
            case 4:
                _damage = 40;
                break;
        }
    }
}
