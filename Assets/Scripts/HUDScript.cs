using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    private Image img;
    public Sprite[] heartSprites;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void updateHealth(int heatlh)
    {
        img.sprite = heartSprites[heartSprites.Length - heatlh - 1];
    }
}
