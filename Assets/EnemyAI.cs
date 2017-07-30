using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  private bool isChasing;
  private Transform player;
  private Rigidbody2D body;
  private float idleDirection;
  private float hp;

  public float activationRange;
  public float chaseSpeed;
  public float idleSpeed;
  public int damage;
  public int health;
  public int drop;
  public GameObject materials;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    body = GetComponent<Rigidbody2D>();
    idleDirection = Random.Range(0, Mathf.PI * 2);
    hp = health;
  }

  private void Update()
  {
    if (!isChasing)
    {
      idleDirection = Random.Range(idleDirection - Time.deltaTime * 10, idleDirection + Time.deltaTime * 10);
      body.velocity = new Vector3(Mathf.Cos(idleDirection), Mathf.Sin(idleDirection), 0) * idleSpeed;
      if((player.position - transform.position).magnitude <= activationRange)
      {
        isChasing = true;
      }
    }
    else
    {
      var direction = player.position - transform.position;
      direction.z = 0;
      direction.Normalize();
      body.velocity = direction * chaseSpeed; 
    }
  }

  public void Damage(float d)
  {
    hp -= d;
    if(hp <= 0)
    {
      var go = Instantiate(materials, transform.position, Quaternion.identity);
      go.GetComponent<Materials>().amount = drop;
      Destroy(gameObject);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.collider.tag == "Player")
    {
      collision.collider.GetComponent<PlayerController>().Damage(damage);
      // TODO play exploding animation
      Destroy(gameObject);
    }
  }
}
