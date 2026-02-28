using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private int currentIndex = 0;

    //private PlayerInputActions inputActions;

    //private void Awake()
    //{
    //    inputActions = new PlayerInputActions();
    //}

    //private void OnEnable()
    //{
    //    inputActions.Enable();

    //    inputActions.Player.Switch1.performed += ctx => currentIndex = 0;
    //    inputActions.Player.Switch2.performed += ctx => currentIndex = 1;
    //    inputActions.Player.Switch3.performed += ctx => currentIndex = 2;

    //    inputActions.Player.Attack.performed += ctx =>
    //    {
    //        //if (HasWeapon())
    //            weapons[currentIndex].TryUse();
    //    };
    //}

    //private void OnDisable()
    //{
    //    inputActions.Disable();
    //}

    //public bool HasWeapon()
    //{
    //    return weapons != null &&
    //           weapons.Length > currentIndex &&
    //           weapons[currentIndex] != null;
    //}
}