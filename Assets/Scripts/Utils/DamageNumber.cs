using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText; // TextMesh component to display damage number
    public float lifetime; // Thời gian tồn tại của số thiệt hại
    private float lifeCounter; // Bộ đếm để theo dõi thời gian tồn tại của số thiệt hại
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // lifetime = Random.Range(0.5f, 1.5f); // Random speed for the damage number
        lifeCounter = lifetime; // lây giá trị từ biến lifetime
        Destroy(gameObject, 1f); // Destroy the damage number after 1 second
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += Vector3.up * Time.deltaTime * lifetime; // Move the damage number upwards
        if(lifeCounter > 0f)
        {
            lifeCounter -= Time.deltaTime; // Decrease the life counter
            if (lifeCounter <= 0f)
            {
                Destroy(gameObject); // Destroy the damage number when the counter reaches zero
            }
        }
    }
    public void SetDamageValue(float value)
    {
        lifeCounter = lifetime; // Reset the life counter to the initial lifetime
        damageText.text = value.ToString(); // Set the text to the damage value
    }
}
