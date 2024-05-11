using UnityEngine;

public class QuestObserver : MonoBehaviour
{
    [SerializeField] private ValvePump _valvePumpQuest;
    [SerializeField] private MathQuestion _mathQuest;
    [SerializeField] private Server _mathServer;
    [SerializeField] private PanelPuzzle _panelPuzzleQuest;

    [Header("Fucking mirror")]
    [SerializeField] private FinishMirror _finishMirror;
    [SerializeField] private GameObject _laserRed;


    private void OnEnable()
    {
        _valvePumpQuest.Complited += UpdateQuestStatus;
        _mathQuest.QuestComplited += UpdateQuestStatus;
        _panelPuzzleQuest.QuestCompleted += UpdateQuestStatus;

        _finishMirror.ComplitedLaser += UpdateQuestStatus;
    }

    private void OnDisable()
    {
        _valvePumpQuest.Complited -= UpdateQuestStatus;
        _mathQuest.QuestComplited -= UpdateQuestStatus;
        _panelPuzzleQuest.QuestCompleted -= UpdateQuestStatus;

        _finishMirror.ComplitedLaser -= UpdateQuestStatus;
    }

    private void UpdateQuestStatus()
    {
        if (_valvePumpQuest.IsDone)
        {

        }

        if (_mathQuest.IsDone)
        {
            _panelPuzzleQuest.CanActivated = true;
        }

        if(_panelPuzzleQuest.IsDone)
        {

        }


        if(_finishMirror.IsDone)
        {

        }


    }
}
