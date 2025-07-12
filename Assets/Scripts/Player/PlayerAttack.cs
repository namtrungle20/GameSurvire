// using UnityEngine;

// public class PlayerAttack : MonoBehaviour
// {
//     [SerializeField] protected bool isAttack = false; // bien kiem soat trang thai tan cong
//     [SerializeField] protected Transform WPAttackPrefab; // vi tri tan cong
//     // Update is called once per frame
//     void Update()
//     {
//         Attack();
//     }
//     protected virtual void Attack()
//     {
//         if (!isAttack) return; // neu khong tan cong thi thoat
//         Vector3 spawnPos = transform.position; // vi tri spawn
//         Quaternion rotation = transform.rotation; // xoay theo huong cua player
//         Instantiate(WPAttackPrefab, spawnPos, rotation); // tao vũ khí tấn công
//         Debug.Log("Player Attack");
//     }
// }
