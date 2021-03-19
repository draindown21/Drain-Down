using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [System.Serializable]
    public class Weapons : MonoBehaviour
    {
        [SerializeField] int weaponID;
        [SerializeField] int totalBullets;


        public int WeaponID { get; }

        public int Bullets
        {
            get { return totalBullets; }
            set { totalBullets = value; }
        }

    }
}
