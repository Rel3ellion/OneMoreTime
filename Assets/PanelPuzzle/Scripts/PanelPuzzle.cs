using System;
using UnityEngine;

public class PanelPuzzle : MonoBehaviour
{
    [SerializeField] private Panel[] _panels = new Panel[9];
    [SerializeField] private ResetButtn _resetButtn;

    public event Action QuestCompleted;

    private Panel[,] _currentPanels;
    public bool CanActivated = false;

    public bool IsDone { get; private set; } = false;

    private void Start()
    {
        _currentPanels = new Panel[,]
        {
            { _panels[0], _panels[1], _panels[2] },
            { _panels[3], _panels[4], _panels[5] },
            { _panels[6], _panels[7], _panels[8] }
        };

        ResetPanels();
    }

    private void OnEnable()
    {
        foreach (var panel in _panels)
        {
            panel.PanelChanged += UpdatePanels;
        }
    }

    private void OnDisable()
    {
        foreach (var panel in _panels)
        {
            panel.PanelChanged -= UpdatePanels;
        }
    }

    public void ResetPanels()
    {
        if (IsDone)
            return;

        foreach (var panel in _panels)
        {
            panel.SetStatus(false);
        }
    }

    public void Activate()
    {
        if (CanActivated == false) return;

        foreach (var panel in _panels)
        {
            panel.Activate();
        }

        _resetButtn.Activate();
    }

    public void Deactivate()
    {
        foreach (var panel in _panels)
        {
            panel.Deactivate();
        }

        _resetButtn.Deactivate();
    }

    private void UpdatePanels(Vector2Int changedPanel)
    {
        Panel bufferPanel;

        if (changedPanel.x > 0)
        {
            bufferPanel = _currentPanels[changedPanel.x - 1, changedPanel.y];
            bufferPanel.SetStatus(bufferPanel.Status == false);
        }

        if (changedPanel.x < 2)
        {
            bufferPanel = _currentPanels[changedPanel.x + 1, changedPanel.y];
            bufferPanel.SetStatus(bufferPanel.Status == false);
        }

        if (changedPanel.y > 0)
        {
            bufferPanel = _currentPanels[changedPanel.x, changedPanel.y - 1];
            bufferPanel.SetStatus(bufferPanel.Status == false);
        }

        if (changedPanel.y < 2)
        {
            bufferPanel = _currentPanels[changedPanel.x, changedPanel.y + 1];
            bufferPanel.SetStatus(bufferPanel.Status == false);
        }

        CheckPanels();
    }

    private void CheckPanels()
    {
        bool status = true;

        foreach (var panel in _panels)
        {
            if (panel.Status == false)
            {
                status = false;
            }
        }

        if (status)
        {
            IsDone = true;
            Debug.Log($"Panel quest is complited = {IsDone}");
            QuestCompleted?.Invoke();
            LockPanels();
        }
    }

    private void LockPanels()
    {
        foreach (var panel in _panels)
        {
            panel.SetLockedStatus(true);
        }
    }
}
