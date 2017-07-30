using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D body;
  private Vector2 input = new Vector2();
  private Transform baseTransform;
  private Animator animator;
  private float gunCooldown = 0;
  private bool reloading = false;
  private LineRenderer reloadProgress;
  private AudioSource hurtsound;

  public float speed;
  public bool canHeld = false;
  public Transform generator;
  public Fuel fuelDisplay;
  public int fuelAmount;
  public GameObject bullet;
  public Gun heldGun;
  public Gun[] guns;
  public int health;
  public GameObject wound;
  public float reloadTimer = 0;
  public int materials = 2000;
  public Transform shoulders;
  public GameObject pistolGrip;
  public GameObject rifleGrip;

  private void Start()
  {
    Bullet.wound = wound;
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
    body = GetComponent<Rigidbody2D>();
    baseTransform = transform.Find("Base");
    animator = GetComponent<Animator>();
    reloadProgress = GetComponent<LineRenderer>();
    hurtsound = GetComponent<AudioSource>();
    //Equip("revolver");
  }

  private void Update()
  {
    if (reloading)
    {
      reloadProgress.SetPosition(1, new Vector3(Mathf.Lerp(-1, 1, reloadTimer / heldGun.reloadTime), -1, 0));
      reloadTimer += Time.deltaTime;
      if(reloadTimer > heldGun.reloadTime)
      {
        reloading = false;
        reloadProgress.enabled = false;
        heldGun.currentClip = heldGun.clipSize;
        reloadTimer = 0;
      }
    }
    else
    {
      if (Input.GetButtonDown("Reload") && heldGun.currentClip < heldGun.clipSize)
      {
        reloading = true;
        reloadProgress.SetPosition(1, new Vector3(-1, -1, 0));
        reloadProgress.enabled = true;
      }
    }
    Facing();
    float distanceFromGenerator = (transform.position - generator.position).magnitude;
    if (distanceFromGenerator <= 3f)
    {
      if (canHeld)
      {
        fuelDisplay.fuel += fuelAmount;
        PickupGas.PlaySound();
        fuelDisplay.jerryCanUI.SetActive(false);
        canHeld = false;
      }
    }
    if(gunCooldown > 0)
    {
      gunCooldown -= Time.deltaTime;
    }
    else
    {
      if (heldGun.isAutomatic)
      {
        if (Input.GetMouseButton(0))
        {
          if (!reloading)
          {
            Fire();
          }
          
        }
      }
      else
      {
        if (Input.GetMouseButtonDown(0))
        {
          if (!reloading)
          {
            Fire();
          }
          
        }
      }
    }
    Movement();
  }

  private void Fire()
  {
    var go = Instantiate(bullet, heldGun.transform.GetChild(2).position, heldGun.transform.GetChild(2).rotation);
    go.GetComponent<Bullet>().damage = heldGun.damage;
    go.GetComponent<Bullet>().initialVelocity = body.velocity;
    gunCooldown = heldGun.rateOfFire;
    heldGun.currentClip--;
    if (heldGun.currentClip <= 0)
    {
      reloading = true;
      reloadProgress.SetPosition(1, new Vector3(-1, -1, 0));
      reloadProgress.enabled = true;
    }
    Gunshot.PlaySound();
  }

  private void Movement()
  {
    input.x = Input.GetAxis("Horizontal");
    input.y = Input.GetAxis("Vertical");
    if(input.magnitude >= 0.1f)
    {
      animator.SetBool("isWalking", true);
    }
    else
    {
      animator.SetBool("isWalking", false);
    }
    input.Normalize();
    input *= speed;
    body.velocity = input;
  }

  private void Facing()
  {
    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition -= baseTransform.position;
    float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
    baseTransform.rotation = Quaternion.Euler(0, 0, angle - 90);
  }

  public void Damage(int d)
  {
    hurtsound.Play();
    health -= d;
    if(health <= 0)
    {
      health = 0;
      GameController.GameOver();
    }
  }

  public void Equip(string gunName)
  {
    foreach (var gun in guns)
    {
      if (gun.gunName == gunName)
      {
        heldGun.gameObject.SetActive(false);
        heldGun = gun;
        heldGun.gameObject.SetActive(true);
        if (heldGun.isRifle)
        {
          shoulders.localRotation = Quaternion.Euler(0, 0, -45);
          pistolGrip.SetActive(false);
          rifleGrip.SetActive(true);
        }
        else
        {
          shoulders.localRotation = Quaternion.Euler(0, 0, 0);
          pistolGrip.SetActive(true);
          rifleGrip.SetActive(false);
        }
        return;
      }
    }
  }
}
