using UnityEngine;
public abstract class Body : MonoBehaviour
{
    public UnitInfo unitInfo;
    public AudioManager audioManager;

    private void Awake()
    {
        if (!audioManager)
            audioManager = GetComponentInChildren<AudioManager>();
    }
    public void RegisterBody(Health health, bool isPlayer)
    {
        DataUnits.RegisterBody(health, isPlayer, unitInfo.id);
    }
}
