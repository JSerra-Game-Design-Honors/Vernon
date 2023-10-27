using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //IN CODE CHANGE THE LAYERS AND TAGS OF EACH PLAYER AND BULLET TO MATCH THEIR PLAYERNUM, ALSO CHANGE COLOR OF HEALTH!!!

    [SerializeField]
    GameObject PlayerPreview;
    [SerializeField]
    Toggle p1Start;
    [SerializeField]
    Toggle p2Start;
    [SerializeField]
    Toggle p3Start;
    [SerializeField]
    GameObject p1Preview;
    [SerializeField]
    GameObject p2Preview;
    [SerializeField]
    GameObject p3Preview;


    public static int p1Class;
    public static int p1Color;
    public static int p2Class;
    public static int p2Color;
    public static int p3Class;
    public static int p3Color;

    private int currentPlayerClass = 0;
    private int currentPlayerColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p1Start.isOn && p2Start.isOn && p3Start.isOn && p1Preview.GetComponent<PlayerPreview>().currentClass != 0 && p1Preview.GetComponent<PlayerPreview>().currentColor != 0 && p2Preview.GetComponent<PlayerPreview>().currentClass != 0 && p2Preview.GetComponent<PlayerPreview>().currentColor != 0 && p3Preview.GetComponent<PlayerPreview>().currentClass != 0 && p3Preview.GetComponent<PlayerPreview>().currentColor != 0)
        {
            p1Class = p1Preview.GetComponent<PlayerPreview>().currentClass;
            p1Color = p1Preview.GetComponent<PlayerPreview>().currentColor;
            p2Class = p2Preview.GetComponent<PlayerPreview>().currentClass;
            p2Color = p2Preview.GetComponent<PlayerPreview>().currentColor;
            p3Class = p3Preview.GetComponent<PlayerPreview>().currentClass;
            p3Color = p3Preview.GetComponent<PlayerPreview>().currentColor;
            SceneManager.LoadScene(1);
        }
    }

    public void classPressed(int i)
    {
        if(currentPlayerClass != i)
        {
            PlayerPreview.GetComponent<PlayerPreview>().changeClass(i);
            currentPlayerClass = i;
        }

    }

    public void colorPressed(int i)
    {
        if(currentPlayerColor != i)
        {
            PlayerPreview.GetComponent<PlayerPreview>().changeColor(i);
            currentPlayerColor = i;
        }
        
    }
}
