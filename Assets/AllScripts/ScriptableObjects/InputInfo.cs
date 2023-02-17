using UnityEngine;
[CreateAssetMenu]
public class InputInfo : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private KeyCode _movingForward;
    [SerializeField] private KeyCode _movingBack;
    [SerializeField] private KeyCode _movingLeft;
    [SerializeField] private KeyCode _movingRight;

    [Header("Attack")]
    [SerializeField] private KeyCode _shot;


    public KeyCode movingForward => _movingForward;
    public KeyCode movingBack => _movingBack;
    public KeyCode movingLeft => _movingLeft;
    public KeyCode movingRight => _movingRight;
    //---------------
    public KeyCode shot => _shot;
}
