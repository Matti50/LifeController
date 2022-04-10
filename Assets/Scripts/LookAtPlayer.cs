using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _rotationSpeed = 100f;

    void Update()
    {
        var playerRefDistance = _playerTransform.position - transform.position;

        var faceToPlayerRotation = Quaternion.LookRotation(playerRefDistance);
        transform.rotation = Quaternion.Lerp(transform.rotation, faceToPlayerRotation, _rotationSpeed * Time.deltaTime);
    }
}
