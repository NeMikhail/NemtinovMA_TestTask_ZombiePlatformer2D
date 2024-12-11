using UnityEngine;
using Core.Interface;
using System;
using Constants;

namespace PlayerModule
{
    public class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _payerObject;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private Rigidbody2D _playerRB;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private GameObject _Object;
        [SerializeField] private SpawnZone _leftSpawnZone;
        [SerializeField] private SpawnZone _rightSpawnZone;
        private Action<int> _onAmmoAdded;
        private Action _onKilled;
        private int _direction;
        private string _viewID;

        public GameObject PayerObject { get => _payerObject; }
        public GameObject Weapon { get => _weapon; }
        public Rigidbody2D PlayerRB { get => _playerRB; }
        public PlayerAnimator Animator { get => _animator; }
        public GroundChecker GroundChecker { get => _groundChecker; }
        public GameObject Object { get => _Object; }
        public SpawnZone LeftSpawnZone { get => _leftSpawnZone; }
        public SpawnZone RightSpawnZone { get => _rightSpawnZone; }
        public Action<int> OnAmmoAdded { get => _onAmmoAdded; set => _onAmmoAdded = value; }
        public Action OnKilled { get => _onKilled; set => _onKilled = value; }
        public int Direction { get => _direction; set => _direction = value; }
        public string ViewID { get => _viewID; set => _viewID = value; }
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == TagsConstantsManager.ENEMY_TAG)
            {
                OnKilled?.Invoke();
            }
        }
    }
}
