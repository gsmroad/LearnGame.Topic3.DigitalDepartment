using UnityEngine;

namespace LearnGame.Shooting
{
    public class ShootingController : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;

        private Weapon _weapon;


        private Collider[] _colliders = new Collider[2];
        private float _nextShotTimerSec;
        private GameObject _target;

        protected void Update()
        {
            _target = GetTarget();

            _nextShotTimerSec -= Time.deltaTime;
            if (_nextShotTimerSec < 0)
            {
                if (HasTarget)
                    _weapon.Shoot(TargetPosition);
                
                _nextShotTimerSec = _weapon.ShootFrequencySec;
            }
        }

        public void SetWeapon(Weapon weaponPrefab, Transform hand)
        {
            _weapon = Instantiate(weaponPrefab, hand);
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }

        private GameObject GetTarget()
        {
            GameObject target = null;

            var position = _weapon.transform.position;
            var radius = _weapon.ShootRadius;
            var maskEnemy = LayerUtils.EnemyMask;
            var maskPlayer = LayerUtils.PLayerMask;

            var sizeEnemy = Physics.OverlapSphereNonAlloc(position, radius, _colliders, maskEnemy);
            if (sizeEnemy > 0)
            {
                for (int i = 0; i < sizeEnemy; i++)
                {
                    if (_colliders[i].gameObject != gameObject)
                    {
                        target = _colliders[i].gameObject;
                        break;
                    }
                }
            }

            var sizePlayer = Physics.OverlapSphereNonAlloc(position, radius, _colliders, maskPlayer);
            if (sizePlayer > 0)
            {
                for (int i = 0; i < sizePlayer; i++)
                {
                    if (_colliders[i].gameObject != gameObject)
                    {
                        target = _colliders[i].gameObject;
                        break;
                    }
                }
            }

            return target;
        }
    }
}