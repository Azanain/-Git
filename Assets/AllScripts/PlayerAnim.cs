using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimDeath()
    { animator.SetTrigger("Death"); }
    public void ShootAnim(bool isShooting)
    {
       animator.SetBool("Shoot", isShooting);
    }
}
