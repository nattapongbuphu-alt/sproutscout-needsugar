using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int maxHP = 100;
    protected int currentHP;

    protected virtual void Awake()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
