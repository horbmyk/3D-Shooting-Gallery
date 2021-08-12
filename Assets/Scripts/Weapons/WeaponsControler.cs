using UnityEngine;

namespace ShootingGallery
{
    public class WeaponsControler : MonoBehaviour
    {
        [SerializeField] private GameObject WeaponHolter;//Holter Weapon in Scene
        private int WeaponSwitch = 0;

        public void SetWeapon(int value)
        {
            WeaponSwitch += value;

            if (WeaponSwitch == WeaponHolter.transform.childCount)
                WeaponSwitch = 0;

            if (WeaponSwitch < 0)
                WeaponSwitch = WeaponHolter.transform.childCount - 1;

            int i = 0;

            foreach (Transform weapon in WeaponHolter.transform)
            {
                if (i == WeaponSwitch)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);

                i++;
            }
        }

        public void PlayShotSound()//ShotSound
        {
            WeaponHolter.transform.GetChild(WeaponSwitch).GetComponent<IWeapon>().PlayShotSound();
        }
    }
}
