using System.Collections;
using UnityEngine;

public class BallisticBullet : Bullet
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Vector2 minNoise;
    [SerializeField] private Vector2 maxNoise;
    public Vector3 _targetPosition;
    private void Awake()
    {
        GetDataInAwake();
    }
    public void StartFindingTarget(Transform target)
    {
        _targetPosition = target.position;
        StartCoroutine(FindTarget());
    }
    private IEnumerator FindTarget()
    {
        Vector3 startPosition = transform.position;
        Vector2 noise = new Vector2(Random.Range(minNoise.x, maxNoise.y), Random.Range(minNoise.y, maxNoise.y));
        Vector3 bulletDirectionVector = new Vector3(_targetPosition.x, _targetPosition.y + yOffset, _targetPosition.z) - startPosition;
        Vector3 horizontalNoiseVector = Vector3.Cross(bulletDirectionVector, Vector3.up).normalized;
        float noisePosition = 0;
        float time = 0;

        while (time < bulletInfo.timeLife)
        {
            noisePosition = _curve.Evaluate(time);
            transform.position = Vector3.Lerp(startPosition, _targetPosition 
                + new Vector3(0, yOffset, 0), time) 
                + new Vector3(horizontalNoiseVector.x * noisePosition * noise.x, noisePosition * noise.y, 
                noisePosition * horizontalNoiseVector.z * noise.x);

            transform.LookAt(_targetPosition + new Vector3(0, yOffset, 0));

            time += Time.deltaTime * bulletInfo.moveSpeed;
            yield return null;
        }
    }
}
