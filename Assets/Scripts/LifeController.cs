using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int _life;

    [SerializeField]
    private int _maxLife = 100;

    private const int _minLife = 0;

    [SerializeField]
    private int _minimumAllowedLife;

    private void Start()
    {
        _life = _maxLife;
    }

    private void Update()
    {
        if(_life <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        _life = Mathf.Max(_minLife, _life - damage);
    }

    public void Heal(int healValue)
    {
        _life = Mathf.Min(_maxLife, _life + healValue);
    }

    public bool CanFollowPlayer()
    {
        return _life >= _minimumAllowedLife;
    }

    public void SetMinimumAllowedLife(int minimumAllowedLife)
    {
        _minimumAllowedLife = minimumAllowedLife;
    }
}
