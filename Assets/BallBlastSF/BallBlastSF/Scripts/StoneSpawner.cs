using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] private int amount; // _amountStone
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    [Space(10)] public UnityEvent Completed;

    private float timer;
    private float amountSpawned; // _amountSpawned;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;

    private int _currentLevel; //“екущий уровень.
    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; } //“екущий уровень.

    private int _progressCountStone; //–асчет колличества камней на уровне, дл€ отображени€ полосы прогресса.
    public int ProgressCountStone { get => _progressCountStone; } //–асчет колличества камней на уровне, дл€ отображени€ полосы прогресса.

    private Color32[] _colors = { new Color32(250, 103, 103, 255),
                                  new Color32(103, 250, 111, 255),
                                  new Color32(250, 168, 250, 255),
                                  new Color32(250, 135, 103, 255),
                                  new Color32(103, 250, 205, 255)};

    private void Start()
    {
        CurrentLevel = PlayerPrefs.GetInt("LevelMenu:CurrentLevel", 1);
        
        int damagePerSecond = (int)( (turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate) );

        maxHitpointsRate += CurrentLevel * 0.02f;

        stoneMaxHitpoints = (int) (damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int) (stoneMaxHitpoints * minHitpointsPercentage);
        
        timer = spawnRate;

        amount += _currentLevel;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();

            timer = 0;
        }
        if (amountSpawned == amount)
        {
            enabled = false;

            Completed.Invoke();
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        stone.StoneViewMaterial.color = _colors[Random.Range(0, _colors.Length)];

        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.maxhitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);

        amountSpawned++;
    }
    
 }
