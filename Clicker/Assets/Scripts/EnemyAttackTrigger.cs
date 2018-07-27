using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour {
    GameObject Target;

    private void OnEnable()
    {
        if (Target != null)
        {
            transform.parent.gameObject.SendMessage("PlayerAttack");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Target = other.gameObject;
        }
    }

    public void ResetTarget()
    {
        Target = null;
    }
}
