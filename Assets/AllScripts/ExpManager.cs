using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public uint currentExp;
    public uint expForLevel = 50;
    public uint level = 1;
    private const float _indexIncreaseExpForLevel = 1.2f;
    [SerializeField] private UI _ui;

    private void Awake()
    {
        EventManager.GainExpEvent += GainExp;
        if (!_ui)
            _ui = GetComponentInParent<UI>();
    }
    private void Start()
    {
        _ui.UpdateExp(0);
    }
    private void GainExp(uint value)
    {
        currentExp += value;

        if (currentExp >= expForLevel)
        {
            uint remains = currentExp - expForLevel;
            currentExp = remains;
            float indexValue = expForLevel * _indexIncreaseExpForLevel;
            expForLevel = (uint)indexValue;
            level++;
            EventManager.LevelUp();
        }

        float index = (float)currentExp / (float)expForLevel;
        _ui.UpdateExp(index);
    }
    private void OnDestroy()
    {
        EventManager.GainExpEvent -= GainExp;
    }
}
