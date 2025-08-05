using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText; // TextMesh component to display damage number
    private float speed; // Speed at which the damage number moves upwards
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1f, 1.5f); // Random speed for the damage number
        Destroy(gameObject, 1f); // Destroy the damage number after 1 second
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime; // Move the damage number upwards
    }
    public void SetDamageValue(float value)
    {
        damageText.text = value.ToString(); // Set the text to the damage value
    }
}
