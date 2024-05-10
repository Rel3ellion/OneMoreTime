using UnityEngine;

public class QuestObserver : MonoBehaviour
{
    [SerializeField] private MathQuestion _mathQuest;
    [SerializeField] private Server _mathServer;
    [SerializeField] private PanelPuzzle _panelPuzzle;

    private void OnEnable()
    {
        _mathQuest.QuestComplited += UpdateQuestStatus;
        _panelPuzzle.QuestCompleted += UpdateQuestStatus;
    }

    private void OnDisable()
    {
        _mathQuest.QuestComplited -= UpdateQuestStatus;
        _panelPuzzle.QuestCompleted -= UpdateQuestStatus;
    }

    private void UpdateQuestStatus()
    {
        if (_mathQuest.IsDone)
        {
            _panelPuzzle.CanActivated = true;
        }


    }
}
