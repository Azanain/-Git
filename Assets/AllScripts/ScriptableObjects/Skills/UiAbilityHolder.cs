using UnityEngine;

public class UiAbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability[] _abilities;
    [SerializeField] private PlayerAbilityHolder _playerAbility;
    [SerializeField] private AbilitySlot[] _abilitySlot;
    [SerializeField] private GameObject _abilitiesPanel;

    [SerializeField] private PlayerBody _playerBody;
    private void Start()
    {
        EventManager.LevelUpEvent += LevelUp;
        Invoke("GetRandomAbility", 3f);
    }
    private void LevelUp()
    {
        GetRandomAbility();
    }
    public void SelectAbility(Ability ability)
    {
        _playerAbility.AddAbility(ability);

        CloseAbilitiesPanel();
    }
    private void CloseAbilitiesPanel()
    {
        _abilitiesPanel.SetActive(false);
    }
    private void GetRandomAbility()
    {
        _abilitiesPanel.SetActive(true);

        Ability abil = null;
        int numberAbil = -1;

        for (int i = 0; i < 3; i++)
        {
            int randAbility = Random.Range(0, _abilities.Length);

            if (randAbility == numberAbil)
                return;

            numberAbil = randAbility;

            if (_abilities[randAbility].levelAbility == 0)
                abil = _abilities[randAbility];
            else if (_abilities[randAbility].levelAbility > 5)
                abil = null;

            _abilitySlot[i].ability = abil;
            _abilitySlot[i]._description = abil.description;
            _abilitySlot[i]._image.sprite = abil.sprite;
        }
    }
    private void OnDestroy()
    {
        EventManager.LevelUpEvent -= LevelUp;
    }
}
