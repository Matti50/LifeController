using UnityEngine;

public class EnemyHealerController : MonoBehaviour, IHealer
{
    [SerializeField]
    public int LifeIncrease { get; set; }

    public void Start()
    {
        LifeIncrease = 50;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;

        Debug.Log("Healing Enemy");
        var enemyHealer = other.GetComponent<LifeController>();
        enemyHealer.Heal(LifeIncrease);        
    }
}
