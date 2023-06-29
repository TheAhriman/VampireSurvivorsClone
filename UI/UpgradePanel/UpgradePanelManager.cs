using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    private PauseManager pauseManager;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    public PauseManager PauseManager
    {
        get => default;
        set
        {
        }
    }

    public UpgradeButton UpgradeButton
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    private void Start()
    {
        HideButtons();
    }
    public void OpenPanel(List<UpgradeData> upgradesData)
    {
        Clean();
        pauseManager.PauseGame();
        upgradePanel.SetActive(true);
        for ( int i = 0; i < upgradesData.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradesData[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID) 
    {
        GameManager.instance.playerTransform.GetComponent<LevelManager>().Upgrade(pressedButtonID);
        ClosePanel();
    }
    public void ClosePanel()
    {
        HideButtons();

        pauseManager.UnPauseGame();
        upgradePanel.SetActive(false);
    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}
