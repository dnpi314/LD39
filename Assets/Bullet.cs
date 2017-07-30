using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed;
  public float damage;
  public Vector3 initialVelocity;

  public static GameObject wound;

  private void Start()
  {
    GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.up * speed) + initialVelocity;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Enemy")
    {
      collision.GetComponent<EnemyAI>().Damage(damage);
      wound.transform.position = transform.position;
      wound.SetActive(true);
      Destroy(gameObject);
    }
    else if(collision.name == "Ground")
    {
      Destroy(gameObject);
    }
  }
}
