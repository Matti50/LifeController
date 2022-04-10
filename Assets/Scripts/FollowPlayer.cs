using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _lerpSpeed = 10f;

    [SerializeField]
    private Transform _playerPosition;

    private LifeController _lifeController;

    [SerializeField]
    private Transform _healingPointPosition;

    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        _lifeController.SetMinimumAllowedLife(20);
    }

    void Update()
    {
        Vector3 whomToGoTo = _lifeController.CanFollowPlayer() ? 
            _playerPosition.position:
            _healingPointPosition.position;

        Vector3 targetPosition = CalculateDirectionTo(whomToGoTo);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private Vector3 CalculateDirectionTo(Vector3 targetPosition)
    {
        var targetRefDistance = targetPosition - transform.position;
        var targetDirection = targetRefDistance.normalized;
        return transform.position + targetDirection * _speed * Time.deltaTime;
    }
}
