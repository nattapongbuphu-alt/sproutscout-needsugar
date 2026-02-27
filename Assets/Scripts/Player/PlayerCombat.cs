using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private int currentIndex = 0;

    void Update()
    {
        HandleWeaponSwitch();

        if (Input.GetMouseButtonDown(0))
        {
            weapons[currentIndex]?.TryUse();
        }
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDonw(keyCode.Alpha1)) currentIndex = 0;
        if (Input.GetKeyDonw(keyCode.Alpha2)) currentIndex = 1;
        if (Input.GetKeyDonw(keyCode.Alpha3)) currentIndex = 2;
    }
}
