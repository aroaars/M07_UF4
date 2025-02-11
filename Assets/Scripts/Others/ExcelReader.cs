using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ExcelReader : MonoBehaviour
{
    public string csv = "Database";
    public List<string> Answers, Questions; //una llista a diferencia d'un array es pot variar la seva llargada quan es vulgui.
    public Button questionButton;
    public TextMeshProUGUI answerText;
    void Start()
    {
        TextAsset text = Resources.Load<TextAsset>(csv);
        if(csv!= null)
        {
            ReadCSV(text.text);
            answerText.text = "";
        }
    }
    private void ReadCSV(string csv)
    {
        string[] rows = csv.Split("\n"); // /n es un salt de linia.
        for (int i=0; i<rows.Length; i++)
        {
            string[] cells = rows[i].Split(","); //split de separacio per coma (,).
            Questions.Add(cells[0]);
            Button newQButton = Instantiate(questionButton, questionButton.transform.parent); //per cada pregunta que tingui es creara un button identic al ja creat. 
            newQButton.GetComponentInChildren<TextMeshProUGUI>().text = cells[0];
            var currentIndex = i; //canvi de text del fill del button, agafar la component TMP de la seguent cell.
            newQButton.onClick.AddListener(() => AnswerTheQuestion(currentIndex));
            /*newQButton.onClick.AddListener(delegate { 
                AnswerTheQuestion(currentIndex);
            } );*/
            Answers.Add(cells[1]);
        }
        questionButton.gameObject.SetActive(false); //desactivo el primer boto (empty button) que es el button posar al principi per indicar com volem els altres botons que seran instanciats.
    }
    public void AnswerTheQuestion(int i) //canvi de la pregunta del button i a la resposta del button i. resposta a la pregunta.
    {
        answerText.text = Answers[i];
    }
}
