using System;

public static class EventManager
{
    public static Action<float> TakeDamageEvent;
    public static Action<uint> GainExpEvent;
    public static Action LevelUpEvent;

    public static void TakeDamage(float index)
    { TakeDamageEvent?.Invoke(index); }
    public static void GainExp(uint value)
    { GainExpEvent?.Invoke(value); }
    public static void LevelUp()
    { LevelUpEvent?.Invoke(); }
}
