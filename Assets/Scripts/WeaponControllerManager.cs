using UnityEngine;

public class WeaponControllerManager : MonoBehaviour
{
    private WeaponController[] _weapons;

    private int currentWeapon = 0;

    void Awake()
    {
        _weapons = GetComponentsInChildren<WeaponController>(true);
        
        SelectNextWeapon();
    }

    void Update()
    {   
        if(OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Selecting Next Gun
            SelectNextWeapon();
        }
    }

    void SelectNextWeapon()
    {
        _weapons[currentWeapon].gameObject.SetActive(true);
        // deactivate other guns
        DeactivateOthers();

        currentWeapon++;
        if(currentWeapon >= _weapons.Length)
            currentWeapon = 0;
    }

    void DeactivateOthers()
    {
        foreach(WeaponController controller in _weapons)
        {
            if(controller != _weapons[currentWeapon])
            {
                controller.gameObject.SetActive(false);
            }
        }
    }
}
