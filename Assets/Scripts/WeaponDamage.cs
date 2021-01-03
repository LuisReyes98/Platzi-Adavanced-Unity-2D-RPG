using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            // Destroy(collision.gameObject);
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
