using UnityEngine;

public class HUDScript : MonoBehaviour
{
    private JohnMovement john;
    private int health;

    public Sprite heartSprite;

    private void Start()
    {
        john = GameObject.FindGameObjectWithTag("Player").GetComponent<JohnMovement>(); ;
        health = john.health;
    }

    public void updateHealth()
    {
        health = john.health;

    }
}
