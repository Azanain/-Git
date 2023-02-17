using System.Collections;
using UnityEngine;
[RequireComponent(typeof(PoolObject))]
[RequireComponent(typeof(AudioSource))]
public abstract class Bullet : MonoBehaviour
{
    public BulletInfo bulletInfo;
    public PoolObject poolObject;
    [SerializeField] private AudioSource _soundShot;
    [HideInInspector] public float lifeTimer;
    public virtual void GetDataInAwake()
    {
        if (!poolObject)
            poolObject = GetComponent<PoolObject>();
    }
    public void OnEnable()
    {
        lifeTimer = bulletInfo.timeLife;
        _soundShot.PlayOneShot(bulletInfo.audioClip);
        StartCoroutine(LifeTimer());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bulletInfo.unitInfo.tagTarget))
            DealDamage(other.transform.root.name);
        else if (other.CompareTag("Obstacles"))
            Destroy();
    }
    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(bulletInfo.timeLife);
        Destroy();
    }
    public void DealDamage(string name)
    {
        Health healthBodyPlayer = DataUnits.GetBody(name);
        healthBodyPlayer.TakeDamage(bulletInfo.damage);
        Destroy();
    }
    public void Destroy()
    {
        poolObject.ReturnToPool();
    }
}
