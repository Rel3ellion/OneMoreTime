using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuestionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _questionPrefab;
    [SerializeField] private MathQuestion _mathQuestion;

    private List<TMP_Text> _textList = new List<TMP_Text>();

    private void OnEnable()
    {
        _mathQuestion.QuestionsCreated += CreateQuestionsUI;
        _mathQuestion.QuestionComplited += UpdateUI;
    }

    private void OnDisable()
    {
        _mathQuestion.QuestionsCreated -= CreateQuestionsUI;
        _mathQuestion.QuestionComplited -= UpdateUI;
    }

    public void Show()
    {
        enabled = true;
    }

    public void Hide()
    {
        enabled = false;
    }

    private void CreateQuestionsUI()
    {
        List<string> textList = _mathQuestion.GetQuestions();

        for (int i = 0; i < _mathQuestion.QuestionsCount; i++)
        {
            TMP_Text questionUI = Instantiate(_questionPrefab, transform);

            questionUI.text = textList[i];

            _textList.Add(questionUI);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _textList.Count; i++)
        {
            if (i < _mathQuestion.CurrentQuestion)
            {
                _textList[i].fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
