using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] int currentWeaponID;

        List<GameObject> weaponsList = new List<GameObject>();

        private void Start()
        {
            int totalWeapons = transform.childCount;

            for(int i = 0; i < totalWeapons; i++)
            {
                weaponsList.Add(transform.GetChild(i).gameObject);
            }
        }

        public void ChangeWeapon()
        {
            ActivateWeapon();

        }

        private void ActivateWeapon()
        {
            int nextWeaponID = currentWeaponID + 1;

            if(nextWeaponID == weaponsList.Count) { nextWeaponID = 0; }

            weaponsList[currentWeaponID].SetActive(false);
            weaponsList[nextWeaponID].SetActive(true);

            currentWeaponID = nextWeaponID;
        }
    }
}
