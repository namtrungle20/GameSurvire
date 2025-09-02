using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObjectDestroy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
