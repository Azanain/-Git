using UnityEngine;
[CreateAssetMenu]
public class AroundFireBoltAbility : Ability
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private string _tagTarget;
    [SerializeField] private float _damage;
    [SerializeField] float _maxSizeSphere;
    private int _numberBolt;

    public override void Activate()
    {
        base.Activate();
        CheckLevel();
        Shot();
    }
    private void Shot()
    { 

        float angle = 0;

        for (int i = 0; i < _numberBolt; i++)
        {
           Instantiate(_bullet, playerBody.transform.position, 
                Quaternion.Euler(new Vector3(playerBody.transform.rotation.x, angle, playerBody.transform.rotation.z)));

            angle += 360 / _numberBolt; 
        }
    }
    public override void CheckLevel()
    {
        switch (levelAbility)
        {
            case 0:
                _numberBolt = 3;
                break;
            case 1:
                _numberBolt = 4;
                break;
            case 2:
                _numberBolt = 5;
                break;
            case 3:
                _numberBolt = 6;
                break;
            case 4:
                _numberBolt = 8;
                break;
        }
    }
}
