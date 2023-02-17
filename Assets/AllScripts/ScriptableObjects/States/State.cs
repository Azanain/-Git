using UnityEngine;
public abstract class State : ScriptableObject
{
    [HideInInspector] public EnemyBody body;
    public virtual void Init() { }
    public abstract void Run();
}
