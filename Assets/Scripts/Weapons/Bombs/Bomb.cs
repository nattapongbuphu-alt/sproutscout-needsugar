using UnityEngine;

public class Bomb : Weapon
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform throwPoint;

    protected override void Use()
    {
        Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
    }
}