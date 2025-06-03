using System.Collections;
using DroneSlayer.PlayerEntity.PlayerSkill;
using DroneSlayer.WeaponEntity;
using UnityEngine;

namespace DroneSlayer.Spawners
{
    public class BulletSpawner : Spawner<Bullet>
    {
        [SerializeField] private PlayerSkills _playerSkills;

        [SerializeField] private float _bulletDamage;
        [SerializeField] private int _bulletsPerShoot = 1;
        [SerializeField] private int _bulletCapacity;
        [SerializeField] private float _bulletSpread;
        [SerializeField] private float _delay;
        [SerializeField] private float _reloadTime;

        [SerializeField] private AudioSource _soundShoot;
        [SerializeField] private AudioSource _soundReload;

        private float _baseBulletDamage;
        private int _baseBulletCapacity;
        private float _baseReloadTime;
        private int _numberPrefabBullet = 0;

        private void OnEnable()
        {
            _playerSkills.DamageChanged += ChangeDamage;
            _playerSkills.CapacityChanged += ChangeCapacity;
            _playerSkills.ReloadChanged += ChangeReloadTime;

            ChangeDamage();
            ChangeCapacity();
            ChangeReloadTime();

            StartCoroutine(SpawnBullets());
        }

        private void OnDisable()
        {
            _playerSkills.DamageChanged -= ChangeDamage;
            _playerSkills.CapacityChanged -= ChangeCapacity;
            _playerSkills.ReloadChanged -= ChangeReloadTime;
        }

        private void Awake()
        {
            Init(_prefabArray[_numberPrefabBullet]);
            _baseBulletDamage = _bulletDamage;
            _baseBulletCapacity = _bulletCapacity;
            _baseReloadTime = _reloadTime;
        }

        public void PutBullet(Bullet bulletPrefab)
        {
            bulletPrefab.DiedEvent -= PutBullet;
            bulletPrefab.gameObject.SetActive(false);
            _objectPool[_numberPrefabBullet].PutObject(bulletPrefab);
        }

        private IEnumerator SpawnBullets()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                var reload = new WaitForSeconds(_reloadTime);
                yield return reload;

                for (int i = 0; i < _bulletCapacity; i++)
                {
                    yield return wait;

                    for (int j = 0; j < _bulletsPerShoot; j++)
                    {
                        _soundShoot.Play();
                        CreateBullet();
                    }
                }

                _soundReload.Play();
            }
        }

        private void CreateBullet()
        {
            Bullet bullet = GetObject(_prefabArray[_numberPrefabBullet]);
            bullet.Init(transform.position, _bulletDamage, _bulletSpread);
            bullet.DiedEvent += PutBullet;
        }

        private void ChangeDamage()
        {
            _bulletDamage = _baseBulletDamage;
            DataSkill dataSkill = _playerSkills.GetSkill(Stats.Damage);
            _bulletDamage *= dataSkill.Values[dataSkill.Level];
        }

        private void ChangeCapacity()
        {
            _bulletCapacity = _baseBulletCapacity;
            DataSkill dataSkill = _playerSkills.GetSkill(Stats.Capacity);
            _bulletCapacity = (int)(_bulletCapacity * dataSkill.Values[dataSkill.Level]);
        }

        private void ChangeReloadTime()
        {
            _reloadTime = _baseReloadTime;
            DataSkill dataSkill = _playerSkills.GetSkill(Stats.ReloadSpeed);
            _reloadTime *= dataSkill.Values[dataSkill.Level];
        }
    }
}