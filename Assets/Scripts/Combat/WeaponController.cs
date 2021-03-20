using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] int currentActiveWeaponID;
        Weapons currentActiveWeapon;

        List<Weapons> weaponsList = new List<Weapons>();

        [SerializeField] AttackController attackController;

        private void OnEnable()
        {
            attackController.AttackStarted += Fire;
            attackController.AttackEnded += StopFire;
        }

        private void Start()
        {
            GetAllAvaliableWeapons();
            currentActiveWeapon = weaponsList[currentActiveWeaponID];
        }

        private void GetAllAvaliableWeapons()
        {
            int totalWeapons = transform.childCount;

            for (int i = 0; i < totalWeapons; i++)
            {
                weaponsList.Add(transform.GetChild(i).GetComponent<Weapons>());
            }

        }

        public void ChangeWeapon()
        {
            ActivateWeapon();

        }

        private void ActivateWeapon()
        {
            int nextWeaponID = currentActiveWeaponID + 1;

            if(nextWeaponID == weaponsList.Count) { nextWeaponID = 0; }

            currentActiveWeapon.gameObject.SetActive(false);
            weaponsList[nextWeaponID].gameObject.SetActive(true);

            currentActiveWeaponID = nextWeaponID;
            currentActiveWeapon = weaponsList[currentActiveWeaponID];
        }

        private void Fire()
        {
            StartCoroutine(enumerator());
            IEnumerator enumerator()
            {
                while (true)
                {
                    GameObject bulletInstance = Instantiate(currentActiveWeapon.Bullet, transform.position, transform.rotation);
                    bulletInstance.transform.position = currentActiveWeapon.BulletHolder.position;
                    bulletInstance.SetActive(true);

                    yield return new WaitForSeconds(currentActiveWeapon.ProjectionRate);
                }
            }
        }

        private void StopFire()
        {
            StopAllCoroutines();
        }
    }
}
