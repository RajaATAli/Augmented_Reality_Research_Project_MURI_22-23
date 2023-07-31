using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    public TMP_Text questionText;
    public List<Button> answerButtons;
    public GameObject resultPanel;
    public TMP_Text resultText;
    
    private int currentQuestionIndex = 0;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestion();   
    }

    public void DisplayQuestion()
{
    // Clearing the answer buttons
    for (int i = 0; i < answerButtons.Count; i++)
    {
        answerButtons[i].onClick.RemoveAllListeners();
        answerButtons[i].gameObject.SetActive(i < questions[currentQuestionIndex].answers.Count);
    }

    // Displaying the current question text
    questionText.text = questions[currentQuestionIndex].questionText;
    
    // Displaying the answer choices (buttons)
    for (int i = 0; i < questions[currentQuestionIndex].answers.Count; i++)
    {
        int buttonIndex = i; 
        answerButtons[i].GetComponentInChildren<TMP_Text>().text = questions[currentQuestionIndex].answers[i];
        answerButtons[i].onClick.AddListener(() => HandleAnswer(buttonIndex)); 
    }
    Debug.Log("DisplayQuestion was called for question index: " + currentQuestionIndex);
}

public void HandleAnswer(int buttonIndex)
{
    Debug.Log("HandleAnswer was called for button index: " + buttonIndex);
    if (buttonIndex == questions[currentQuestionIndex].correctAnswerIndex)
    {
        score++; 
        resultText.text = "Score: " + score; 
    }

    currentQuestionIndex++; 
    
     if (currentQuestionIndex < questions.Count)
     {
         DisplayQuestion();
     }
     else
     {
         // If there are no more questions, display the score
         EndQuiz();
     }
}



    public void EndQuiz()
{

    questionText.gameObject.SetActive(false);
    foreach (Button button in answerButtons)
    {
        button.gameObject.SetActive(false);
    }

    resultPanel.SetActive(true);
    resultText.text = "Score: " + score;
}


    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> answers;
    public int correctAnswerIndex;
}

