using UnityEngine;

public class PlayerHealerController : MonoBehaviour, IHealer
{
    public int LifeIncrease { get; set; }

    void Start()
    {
        LifeIncrease = 10;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        var player = other.GetComponent<LifeController>();
        Debug.Log("Healing Player");

        player.Heal(LifeIncrease);
    }
}
