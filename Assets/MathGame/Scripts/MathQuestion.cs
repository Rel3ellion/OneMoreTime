using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MathQuestion : MonoBehaviour
{
    [SerializeField] private UnityEvent _rightAnswer;
    [SerializeField] private UnityEvent _wrongAnswer;

    public event Action QuestionsChanged;
    public event Action QuestionComplited;
    public event Action QuestComplited;

    private List<Question> _questions = new List<Question>();

    private int _countQuestions = 6;
    private int _minNumber = 0;
    private int _maxNumber = 10;

    public bool IsDone { get; private set; } = false;
    public int CurrentQuestion { get; private set; } = 0;

    public int QuestionsCount => _questions.Count;

    public void CheckAnsver(int answer, out bool isRight)
    {
        isRight = false;
        if (IsDone) return;

        if (answer == _questions[CurrentQuestion].Answer)
        {
            isRight = true;
            CurrentQuestion++;
            QuestionComplited?.Invoke();
            _rightAnswer?.Invoke();
            Debug.Log("Current question " + CurrentQuestion);

            if (CurrentQuestion == _questions.Count)
            {
                IsDone = true;
                Debug.Log("QuestIs done = " + IsDone);
            }

            return;
        }
        else
        {
            _wrongAnswer?.Invoke();
            CreateQuestions();

            return;
        }
    }

    public void CheckAnsver(int answer)
    {
        if (IsDone) return;

        if (answer == _questions[CurrentQuestion].Answer)
        {
            CurrentQuestion++;
            QuestionComplited.Invoke();
            _rightAnswer?.Invoke();
            Debug.Log("Current question " + CurrentQuestion);
            
            if (CurrentQuestion == _questions.Count)
            {
                IsDone = true;
                Debug.Log("QuestIs done = " + IsDone);
                QuestComplited?.Invoke();
            }

            return;
        }
        else
        {
            _wrongAnswer?.Invoke();
            CreateQuestions();

            return;
        }
    }

    public List<string> GetQuestions()
    {
        List<string> questions = new List<string>();

        char mathSymbol;

        foreach (Question question in _questions)
        {
            if (question.Operation == EnumOperation.Pluss)
            {
                mathSymbol = '+';
            }
            else
            {
                mathSymbol = '-';
            }

            questions.Add($"MOD(|{question.FirstNumber} {mathSymbol} {question.SecondNumber}|)");
        }

        return questions;
    }

    public void ClearQuestions()
    {
        CurrentQuestion = 0;

        _questions.Clear();
        QuestionsChanged.Invoke();
    }

    public void CreateQuestions()
    {
        EnumOperation operation;
        int firstNumber;
        int secondNumber;

        CurrentQuestion = 0;

        _questions.Clear();

        for (int i = 0; i < _countQuestions; i++)
        {
            firstNumber = Random.Range(_minNumber, _maxNumber);
            secondNumber = Random.Range(_minNumber, _maxNumber);

            if (Random.Range(0, 2) == 0)
            {
                operation = EnumOperation.Minus;
            }
            else
            {
                operation = EnumOperation.Pluss;
            }

            _questions.Add(new Question(firstNumber, secondNumber, operation));
        }

        QuestionsChanged.Invoke();
    }

    private struct Question
    {
        public Question(int firstNumber, int secondNumber, EnumOperation operation)
        {
            Answer = 0;
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;

            if (operation == EnumOperation.Minus)
            {
                Answer = Mathf.Abs(firstNumber - secondNumber) % 10;
            }
            else if (operation == EnumOperation.Pluss)
            {
                Answer = Mathf.Abs(firstNumber + secondNumber) % 10;
            }
        }

        public int Answer { get; private set; }
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public EnumOperation Operation { get; private set; }
    }
}
