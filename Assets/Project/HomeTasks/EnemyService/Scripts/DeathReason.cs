// using UnityEngine;
// using Debug = UnityEngine.Debug;
//
// public class DeathReason : MonoBehaviour
// {
//     private bool _isDead;
//     private float _deadBirth = 1f;
//     private float _lifeTime = 5f;
//     
//     public void Update()
//     {
//         _lifeTime -= Time.deltaTime;
//
//         if (_lifeTime <= 0f)
//         {
//             Destroy(gameObject);
//             Debug.Log("Time has expired, Bye");
//         }
//     }
//
//     public void DeadBirth()
//     {
//         if (_deadBirth <= 0f)
//         {
//             Destroy(gameObject);
//             Debug.Log("Deadborn Kid");
//         }
//     }
//     
//     public void LackOfSpace()
//     {
//         EnemyService enemies = GetComponentInParent<EnemyService>();
//         
//         if (enemies.Enemies.Count >= 5)
//         {
//             Destroy(gameObject);
//         }
//     }
// }