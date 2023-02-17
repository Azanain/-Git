using UnityEngine;

public class SimpleBullet : Bullet
{
    private void Awake()
    {
        GetDataInAwake();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * bulletInfo.moveSpeed * Time.deltaTime);
    }
}
