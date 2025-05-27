using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float moveSpeed;
    float timeDestroy;
    [HideInInspector]
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet(){
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
