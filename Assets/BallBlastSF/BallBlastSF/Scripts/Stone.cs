using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    public enum Size
    {
        Small,
        Normall,
        Big,
        Huge
    }

    [SerializeField] private Size size;
    [SerializeField] private float spawnUpForce;
    [SerializeField] private int maxCoinRandom; //Максимальное число рандома монет.
    [SerializeField] private Coin CoinPrefab;

    [SerializeField] private SpriteRenderer _stoneViewMaterial; //Материал камня.
    public SpriteRenderer StoneViewMaterial { get => _stoneViewMaterial; set => _stoneViewMaterial = value; }

    private StoneMovement movement;
    private void Awake()
    {
        movement = GetComponent<StoneMovement>();

        Distruct.AddListener(OnStoneDestroyed);

        SetSize(size);
    }

    private void OnDestroy()
    {
        Distruct.RemoveListener(OnStoneDestroyed);
    }

    private void OnStoneDestroyed()
    {
        if (size != Size.Small)
        {
            SpawnStones();           
        }

        Destroy(gameObject);
    }

    private void SpawnStones()
    {
        int rndCoin = Random.Range(1, maxCoinRandom);

        if (rndCoin == 2)
        {
            Coin coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);

            coin.GetComponent<Movement>().AddVertivalVelocity(spawnUpForce / 2);
        }
        for (int i = 0; i < 2; i++)
        {
            Stone stone = Instantiate(this, transform.position, Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxhitPoints = Mathf.Clamp(maxhitPoints / 2, 1, maxhitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SethorizontalDirection((i % 2 * 2) - 1);
        }
    }

    public void SetSize(Size size)
    {
        if (size < 0) return;
        
        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }
    
    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1); 
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normall) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }
}
   
