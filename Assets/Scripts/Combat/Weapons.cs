using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [System.Serializable]
    public class Weapons : MonoBehaviour
    {
        [SerializeField] int weaponID;
        [SerializeField] GameObject bullet;
        [SerializeField] int mazineSize;
        [SerializeField] int range;
        [Range(0, 2)] [SerializeField] float projectionRate;
        [SerializeField] int damage;
        [SerializeField] Transform bulletHolder; 

        public int WeaponID { get { return weaponID; } }

        public GameObject Bullet { get { return bullet; } }

        public int MazineSize { get { return mazineSize; } }

        public int Range { get { return range; } }

        public float ProjectionRate { get { return projectionRate; } }

        public int Damage { get { return damage; } }

        public Transform BulletHolder { get { return bulletHolder; } }

    }
}
