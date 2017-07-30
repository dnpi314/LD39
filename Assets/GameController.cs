using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  private bool cursorLocked;
  private static GameController _Instance;
  private float increaseCooldown;
  private int currentEnemies;
  private bool gameActive = false;
  private Scene game;
  public int threshhold;
  private float timer;

  public float outer;
  public float outerMax;
  public float inner;
  public float innerMax;
  public int cans;
  public float distanceIncrease;
  public float spawnDistance = 30;
  public int maxEnemies;
  public float enemyIncreaseTimer;
  public float[] enemySpawnThresholds;

  public GameObject startScreen;
  public GameObject gameOverScreen;
  public GameObject jerryCan;
  public GameObject[] monsters;
  public Transform player;

  public GameObject[] enableThese;
  public PlayerController playerCon;

  private void Start()
  {
    _Instance = this;
    game = SceneManager.GetActiveScene();
    enableThese[2].SetActive(false);
  }

  private void Update()
  {
    if (!gameActive)
    {
      return;
    }
    outer += Time.deltaTime * distanceIncrease;
    if(outer >= outerMax)
    {
      outer = outerMax;
    }
    inner += Time.deltaTime * distanceIncrease * 0.5f;
    if(inner >= innerMax)
    {
      inner = innerMax;
    }
    increaseCooldown -= Time.deltaTime;
    if(increaseCooldown <= 0)
    {
      increaseCooldown = enemyIncreaseTimer;
      maxEnemies++;
    }
    if(currentEnemies < maxEnemies)
    {
      SpawnMonster();
    }

    timer += Time.deltaTime;
    if(threshhold < 3 && timer >= enemySpawnThresholds[threshhold + 1])
    {
      threshhold++;
    }
  }

  public static void GameOver()
  {
    Cursor.visible = true;
    _Instance.gameOverScreen.SetActive(true);
    foreach (var go in _Instance.enableThese)
    {
      go.SetActive(false);
    }
    _Instance.playerCon.enabled = false;
  }

  public void StartGame()
  {
    startScreen.SetActive(false);
    foreach (var go in enableThese)
    {
      go.SetActive(true);
    }
    playerCon.enabled = true;
    SpawnInitial();
    gameActive = true;
  }

  private void SpawnInitial()
  {
    for (int i = 0; i < cans; i++)
    {
      SpawnCan();
    }
    for (int i = 0; i < maxEnemies; i++)
    {
      SpawnMonster();
    }
    increaseCooldown = enemyIncreaseTimer;
  }

  public static void SpawnCan()
  {
    var location = new Vector3();
    float o = _Instance.outer;
    float i = _Instance.inner;
    int quad = Random.Range(0, 8);
    switch (quad)
    {
      case 0:
        location.x = Random.Range(-o, -i);
        location.y = Random.Range(i, o);
        break;
      case 1:
        location.x = Random.Range(-i, i);
        location.y = Random.Range(i, o);
        break;
      case 2:
        location.x = Random.Range(i, o);
        location.y = Random.Range(i, o);
        break;
      case 3:
        location.x = Random.Range(-o, -i);
        location.y = Random.Range(-i, i);
        break;
      case 4:
        location.x = Random.Range(i, o);
        location.y = Random.Range(-i, i);
        break;
      case 5:
        location.x = Random.Range(-o, -i);
        location.y = Random.Range(-o, -i);
        break;
      case 6:
        location.x = Random.Range(-i, i);
        location.y = Random.Range(-o, -i);
        break;
      case 7:
        location.x = Random.Range(i, o);
        location.y = Random.Range(-o, -i);
        break;
      default:
        break;
    }

    Instantiate(_Instance.jerryCan, location, Quaternion.identity);
  }

  private void SpawnMonster()
  {
    var position = (Vector3)Random.insideUnitCircle * 75f;
    bool spawnSuccesful = false;
    int loopCount = 0;
    while (!spawnSuccesful)
    {
      float playerDistance = (player.position - position).magnitude;
      float lightDistance = position.magnitude;
      if(playerDistance > spawnDistance && lightDistance > 20)
      {
        int index = Random.Range(0, threshhold + 1);
        spawnSuccesful = true;
        Instantiate(monsters[index], position, Quaternion.identity);
        currentEnemies++;
      }
      loopCount++;
      if(loopCount > 10)
      {
        break;
      }
    }
  }

  public void Quit()
  {
    Cursor.lockState = CursorLockMode.None;
    Application.Quit();
  }

  public void Restart()
  {
    SceneManager.LoadScene(game.buildIndex);
  }
}
