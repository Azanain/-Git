using UnityEngine;
public class PlayerHealth : Health
{
    [SerializeField] private PlayerBody _playerBody;
    private void Start()
    {
        if (!_playerBody)
            _playerBody = GetComponent<PlayerBody>();

        GetDataInStart(_playerBody);
        EventManager.TakeDamage(Index);
    }
    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
        _playerBody.audioManager.SoundHit();
        EventManager.TakeDamage(Index);
    }
    public override void Death()
    {
        _playerBody.playerAnim.AnimDeath();
    }
}
