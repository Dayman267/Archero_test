using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private int selectedWeapon;

    private void Start()
    {
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i==selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int equippedWeapon = selectedWeapon;

        if (collider.gameObject.CompareTag("Shotgun"))
        {
            selectedWeapon = 1;
            collider.gameObject.SetActive(false);
        }
        else if (collider.gameObject.CompareTag("Famas"))
        {
            selectedWeapon = 2;
            Destroy(collider.gameObject);
        }
        
        if(equippedWeapon != selectedWeapon) SelectWeapon();
    }
}
