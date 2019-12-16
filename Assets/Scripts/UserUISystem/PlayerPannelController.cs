using UnityEngine;
using UnityEngine.UI;

public class PlayerPannelController
{
    Text _bulletsRemain;
    Image[] _healthRemain;

    public PlayerPannelController(GameObject playerPannel)
    {
        Transform healthPannel = playerPannel.transform.GetChild(0); 
        int healthCount = healthPannel.childCount;
        _healthRemain = new Image[healthCount];

        for (int i = 0; i < healthCount; i++)
        {
            _healthRemain[i] = healthPannel.GetChild(i).GetComponentInChildren<Image>();
        }

        _bulletsRemain = playerPannel.transform.GetChild(1).GetComponentInChildren<Text>();

        GameManager.Instanse.GameEventSystem.UpdateHealthValue += OnUpdateHealthValue;
        GameManager.Instanse.GameEventSystem.UpdateStrongBulletValue += OnUpdateStrongBullerValue;
    }

    void OnUpdateStrongBullerValue(int value)
    {
        _bulletsRemain.text = value.ToString();
    }

    void OnUpdateHealthValue(int currentHealth)
    {
        for (int i = 0; i < _healthRemain.Length; i++)
        {
            if(i <= currentHealth) 
            {
                _healthRemain[i].gameObject.SetActive(true);
            }
            else
            {
                _healthRemain[i].gameObject.SetActive(false);
            }
        }
    }
}
