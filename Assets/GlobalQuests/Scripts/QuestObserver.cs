using UnityEngine;

public class QuestObserver : MonoBehaviour
{
    [SerializeField] private ValvePump _valvePumpQuest;
    [SerializeField] private MathQuestion _mathQuest;
    [SerializeField] private Server _mathServer;
    [SerializeField] private PanelPuzzle _panelPuzzleQuest;

    private void OnEnable()
    {
        _valvePumpQuest.Complited += UpdateQuestStatus;
        _mathQuest.QuestComplited += UpdateQuestStatus;
        _panelPuzzleQuest.QuestCompleted += UpdateQuestStatus;
    }

    private void OnDisable()
    {
        _valvePumpQuest.Complited -= UpdateQuestStatus;
        _mathQuest.QuestComplited -= UpdateQuestStatus;
        _panelPuzzleQuest.QuestCompleted -= UpdateQuestStatus;
    }

    private void UpdateQuestStatus()
    {
        if (_mathQuest.IsDone)
        {
            _panelPuzzleQuest.CanActivated = true;
        }


    }
}
