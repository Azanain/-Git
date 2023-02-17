using UnityEngine;
[RequireComponent(typeof(PlayerAnim))]
[RequireComponent(typeof(SystemInputCharacter))]
[RequireComponent(typeof(Pool))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAbilityHolder))]
public class PlayerBody : Body
{
    public PlayerAnim playerAnim;
    public SystemInputCharacter systemInputCharacter;
    public Pool pool;
    public PlayerHealth playerHealth;
    public PlayerAbilityHolder playerAbilityHolder;
    private void Awake()
    {
        if (!playerAnim)
            playerAnim =  GetComponent<PlayerAnim>();
        if (!systemInputCharacter)
            systemInputCharacter =  GetComponent<SystemInputCharacter>();
        if (!pool)
            pool = GetComponent<Pool>();
        if (!playerHealth)
            playerHealth = GetComponent<PlayerHealth>();
        if (!playerAbilityHolder)
            playerAbilityHolder = GetComponent<PlayerAbilityHolder>();

        RegisterBody(playerHealth, true);
    }
}
