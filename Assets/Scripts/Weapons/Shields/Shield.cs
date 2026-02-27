using UnityEngine;
using System.Collections;

public class Shield : Weapon
{
    [SerializeField] private float duration = 2f;
    private bool isActive = false;

    protected override void Use()
    {
        if (!isActive)
            StartCoroutine(ShieldRoutine());
    }

    IEnumerator ShieldRoutine()
    {
        isActive = true;
        yield return new WaitForSeconds(duration);
        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }
}