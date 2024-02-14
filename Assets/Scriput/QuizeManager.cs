using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;

public class QuizeManager : MonoBehaviour
{
    public TextAsset csvFile;
    private List<QuestionData> questions = new List<QuestionData> ();//問題データを保持する

    // Start is called before the first frame update
    void Start()
    {
        if (csvFile != null) 
        {
            ParserCSV();
            DisplayQuestion(0);
        }
        else
        {
            Debug.LogError("CSVファイルが読み込みません");
        }
        
    }

    void ParserCSV()
    {
        string[] lines = csvFile.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');
            QuestionData question= new QuestionData();
            question.questionText = data[0];
            question.choices = new string[] { data[1], data[2], data[3], data[4] };
            question.correnctAnswer = int.Parse(data[5]);

            questions.Add(question);

        }
    }
    // Update is called once per frame
    void DisplayQuestion(int index)
    {
        if (index >= 0 && index <questions.Count)
        {
            QuestionData currentQuestion = questions[index];
            Debug.Log($"問題:{currentQuestion.questionText}");
            //選択肢表示
            for (int i = 0;i < currentQuestion.choices.Length; i++)
            {
                Debug.Log($"選択肢{i + 1}:{currentQuestion.choices[i]}");
            }
            //正解番号を表示
            Debug.Log($"正解番号:{currentQuestion.correnctAnswer}");
        }
        else
        {
            Debug.LogError("指定された問題は存在しません。");
        }
    }

    public class QuestionData
    {
        public string questionText;
        public string[] choices;
        public int correnctAnswer;
    }
}
