using System;
using UnityEngine;

namespace DroneSlayer.WeaponEntity
{
    public class Bullet : MonoBehaviour
    {
        private float _flightSpeed = 5f;
        private float _bulletSpread = 0;

        public float Damage { get; private set; } = 50;

        public event Action<Bullet> DiedEvent;


        private void Update()
        {
            FlightDirection(_bulletSpread);
        }

        private void OnTriggerEnter(Collider other)
        {
            DiedEvent?.Invoke(this);
        }

        public void Init(Vector3 vector3, float damage, float direction)
        {
            gameObject.SetActive(true);
            Damage = damage;
            _bulletSpread = UnityEngine.Random.Range(-direction, direction);
            transform.position = new Vector3(vector3.x, vector3.y, vector3.z);
        }

        private void FlightDirection(float flightDirection)
        {
            transform.Translate(-_flightSpeed * Time.deltaTime, 0, flightDirection * Time.deltaTime);
        }
    }
}