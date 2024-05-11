using UnityEngine;

public class Server : MonoBehaviour
{
    [SerializeField] private CastomServerButton[] _serverButtons;
    [SerializeField] private MathQuestion _mathQuest;

    public bool CanActivated = false;

    public void Activate()
    {
        if (CanActivated == false) return;

        _mathQuest.CreateQuestions();

        foreach (var button in _serverButtons)
        {
            button.Activate();
        }
    }

    public void Deactivate()
    {
        _mathQuest.ClearQuestions();

        foreach (var button in _serverButtons)
        {
            button.Deactivate();
        }
    }
}
