using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    [SerializeField] private UiAbilityHolder _uiAbilityHolder;
    public Image _image;
    public Text _descriptionPanel;
    public Ability ability;

    [Space(5)]
    public string _description;
    private void OnMouseDown()
    {
        _uiAbilityHolder.SelectAbility(ability);
    }
    private void OnMouseEnter()
    {
        _descriptionPanel.text = _description;
    }
    private void OnDisable()
    {
        _image = null;
        _description = null;
    }
}
