using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletTag"))
        {
            Destroy(gameObject);
            GameController.Instance.OnKill();
        }
    }
}
