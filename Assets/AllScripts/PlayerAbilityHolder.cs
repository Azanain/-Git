using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAbilityHolder : MonoBehaviour
{
    [SerializeField] private PlayerBody _playerBody;
    [SerializeField] private Image[] _imagesSelectedAbility;
    [SerializeField] private Image[] _imagesCooldownSelectedAbility;
    private int _numberSelectedImage;
    private Coroutine _routine;

    public List<Ability> abilities = new List<Ability>();

    public void AddAbility(Ability ability)
    {
        abilities.Add(ability);
        _imagesSelectedAbility[_numberSelectedImage].sprite = ability.sprite;
        _imagesSelectedAbility[_numberSelectedImage].gameObject.SetActive(true);
        _routine = Coroutines.StartRoutine(CooldownAbility(ability.cooldown, _numberSelectedImage, ability));

        _numberSelectedImage++;
    }
    private IEnumerator CooldownAbility(float cooldown, int numberAbility, Ability ability)
    {
        ActivateAbility(ability);
        float timer = 0;
        int number = numberAbility;
        _imagesCooldownSelectedAbility[number].fillAmount = 0;

        while (timer < cooldown)
        {
            timer += Time.deltaTime;
            _imagesCooldownSelectedAbility[number].fillAmount = timer / cooldown;
            yield return null;
        }
        if (timer >= cooldown)
        {
            _imagesCooldownSelectedAbility[number].fillAmount = 1;
            _routine = Coroutines.StartRoutine(CooldownAbility(cooldown, numberAbility, ability));
        }
    }
    private void ActivateAbility(Ability ability)
    {
        ability.playerBody = _playerBody;
        ability.Activate();
    }
}
