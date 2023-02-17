using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float currentHp;
    public float MaxHp { get; private set; }
    public float Index { get; private set; }
    public virtual void GetDataInStart(Body body)
    {
        MaxHp = body.unitInfo.maxHp;
        currentHp = MaxHp;
        Index = currentHp / MaxHp;
    }
    public virtual void TakeDamage(float value)
    {
        currentHp -= value;

        if (currentHp <= 0)
        {
            currentHp = 0;
            Index = 0;
            Debug.Log("die");
            Death();
        }
        else if(currentHp > MaxHp)
            currentHp = MaxHp;

        Index = currentHp / MaxHp;
    }
    public virtual void Death() 
    { }
}
