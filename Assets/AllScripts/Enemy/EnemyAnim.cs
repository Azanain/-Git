using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        if(!_animator)
            _animator = GetComponent<Animator>();
    }
    public void IdleAnim()
    {
        _animator.SetBool("Move", false);
    }
    public void MoveAnim()
    {
        _animator.SetBool("Move", true);
    }
    public void DeathAnim()
    {
        _animator.SetTrigger("Death");
    }
    public void StartAttackAnim()
    {
        _animator.SetBool("Attack", true);
    }
    public void StopAttackAnimEvent()
    {
        _animator.SetBool("Attack", false);
    }
}
