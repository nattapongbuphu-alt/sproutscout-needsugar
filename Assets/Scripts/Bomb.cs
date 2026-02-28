using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explodeTime = 2f;
    public float force = 8f;

    void Start()
    {
        Destroy(gameObject, explodeTime);
    }
}
