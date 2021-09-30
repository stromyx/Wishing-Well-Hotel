using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Inky : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public Text textPrefab;
    public Button buttonPrefab;
    //Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);

        refreshUI();




        //foreach (Choice choice in story.currentChoices)
        //{
        //    Button choiceButton = Instantiate(buttonPrefab) as Button;
        //    Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
        //    choiceButton.transform.SetParent(this.transform, false);
        //}
        //story.ChooseChoiceIndex(0);
        //Debug.Log(loadStory());
        //Debug.Log(loadStory());
    }

    void refreshUI()
    {
        eraseUI();
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = loadStory();
        Debug.Log(storyText.text);
        storyText.transform.SetParent(this.transform, false);

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            choiceButton.onClick.AddListener(delegate
            {
                chooseStoryChoice(choice);
            });
        }
    }
    void eraseUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }
    // Update is called once per frame
    void Update()
    {

    }

    string loadStory()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        return text;

    }
}
