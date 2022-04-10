using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private int _saluteAnimationId = Animator.StringToHash("Salute");
    private int _walkAnimationId = Animator.StringToHash("IsWalking");

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _speedIncrease = 1.5f;

    [SerializeField]
    private float _initialSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    private BulletSpawner _bulletSpawner;

    private LifeController _lifeController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();
        _bulletSpawner = gameObject.GetComponentInChildren<BulletSpawner>();
    }

    private void Start()
    {
        _speed = _initialSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger(_saluteAnimationId);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _bulletSpawner.SpawnBullet();
        }

        var directionY = Input.GetAxis("Vertical");
        var directionX = Input.GetAxis("Horizontal");

        var direction = new Vector3(directionX, 0f, directionY);

        var mouseX = Input.GetAxis("Mouse X");

        Move(direction);
        Rotate(mouseX);
    }

    private void Move(Vector3 direction)
    {
        var isWalking = direction.x != 0 || direction.z != 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= _speedIncrease;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
        }
        var newDirection = _speed * Time.deltaTime * direction.normalized;

        _animator.SetBool(_walkAnimationId, isWalking);

        transform.Translate(newDirection, Space.Self);
    }

    private void Rotate(float direction)
    {
        transform.Rotate(new Vector3(0f, direction, 0f) * _rotationSpeed * Time.deltaTime, Space.Self);
    }
}
