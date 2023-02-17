using UnityEngine;
public class Ability : ScriptableObject
{
    [HideInInspector] public PlayerBody playerBody;
    [SerializeField] private float _cooldown;
    public float cooldown => _cooldown;
    public string description;
    public Sprite sprite;

    public new string name;
    public float duration;
    public ParticleSystem particleSystem;
    public AudioClip audioClip;
    public int levelAbility;
    //public float CurrentTime { get; private set; }

    //private Coroutine _routine;

    public virtual void Activate()
    { }
    //public IEnumerator TimerCooldown()
    //{
    //    Activate();
    //    CurrentTime = 0;

    //    while (CurrentTime < cooldown)
    //    {
    //        CurrentTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    if (CurrentTime >= cooldown)
    //    {
    //        CurrentTime = 0;
    //        _routine = Coroutines.StartRoutine(TimerCooldown());
    //    }
    //}
    public virtual void CheckLevel()
    { }
}
