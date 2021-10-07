using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject itemsToHide;
    public GameObject itemsToShow;
    public GameObject itemsToTransform;
    public GameObject player;
    [SerializeField] float cd;
    public bool isHide = false;
    public Transform backpack;





    public void GoToRoomOne()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToRoomTwo()
    {
        SceneManager.LoadScene(2);
    }


    public void OnButtonClicked(int index)
    {
        StartCoroutine(Cooldown(index));
    }
    public IEnumerator Cooldown(int index)
    {
        yield return new WaitForSeconds(cd);
        switch (index)
        {
            case 1:
                GoToRoomOne();
                break;
            case 2:
                GoToRoomTwo();
                break;
            case 3:
                GetItem();
                break;
            case 4:
                ShowIt();
                break;
            case 5:
                QuitGame();
                break;
        }
    }

    public void GetItem()
    {
        player.SetActive(true);
    }

    public void HideItems()
    {
        Instantiate(itemsToHide, backpack);
        if (itemsToHide.activeInHierarchy)
        // Destroy(itemsToHide, 5f);
        {
            itemsToHide.SetActive(false);
            isHide = true;
            Debug.Log(isHide);
        }
        else
            itemsToHide.SetActive(true);
    }

    public void ShowIt()
    {

        itemsToShow.SetActive(true);
    }



    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
