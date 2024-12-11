using Core.Interface;
using PlayerModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AmmoUIView : MonoBehaviour, IView
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Image _ammoImage;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _ammoCountText;
    private PlayerModel _playerModel;
    private string _viewID;

    public GameObject Object { get => _object; }
    public string ViewID { get => _viewID; set => _viewID = value; }


    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _ammoImage.sprite = _playerModel.WeaponModel.BulletIconSprite;
        _playerModel.WeaponModel.OnAmmoCountChanged += UpdateInfo;
    }

    private void OnDestroy()
    {
        _playerModel.WeaponModel.OnAmmoCountChanged -= UpdateInfo;
    }

    public void UpdateInfo()
    {
        _ammoCountText.text =
            $"{_playerModel.WeaponModel.AmmoCount} / {_playerModel.WeaponModel.MaxAmmoCount}";
        _slider.value = (float)_playerModel.WeaponModel.AmmoCount / (float)_playerModel.WeaponModel.MaxAmmoCount;
    }
}
