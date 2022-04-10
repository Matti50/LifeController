using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private BulletController _bulletPrefab;

    public void SpawnBullet()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}