using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown = 1f;
    protected float lastUseTime;

    public void TryUse()
    {
        if (Time.time >= lastUseTime + cooldown)
        {
            Use();
            lastUseTime = Time.time;
        }
    }

    protected abstract void Use();

}
