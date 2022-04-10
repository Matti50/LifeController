using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private int _damage;

    private void Start()
    {
        _damage = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var playerLife = other.GetComponent<LifeController>();
            playerLife.TakeDamage(_damage);
        }
    }
}
