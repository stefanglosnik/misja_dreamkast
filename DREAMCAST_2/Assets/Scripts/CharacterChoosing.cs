using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChoosing : MonoBehaviour
{
    //co jest klikane?
    public Vector2 _inputAxis;
    //tablica z postaciami do wyboru
    public GameObject[] Postacie;
    //po³o¿enie wskaŸnika w odniesieniu do indeksu postaci
    public int indicatorLocation;

    //kontrola zbyt szybkiego przesuwania
    private int selectionTimer = 0;
    int selectionTime = 10;

    public static int wyborPostaci;

    private GameObject ramka;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Start is called before the first frame update
    void Start()
    {
        indicatorLocation = 0;
        ramka = GameObject.Find("RamkaWyboru");
        ramka.transform.position = Postacie[indicatorLocation].transform.position;

        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/StreamingAssets/scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the Return key is pressed down
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        if (selectionTimer == 0)
        {
            _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_inputAxis.x > 0)
            {
                Prawo();
                selectionTimer++;
            }
            if (_inputAxis.x < 0)
            {
                Lewo();
                selectionTimer++;
            }
        }
        else
        {
            selectionTimer++;
            if(selectionTimer > selectionTime)
            {
                selectionTimer = 0;
            }
        }

        ramka.transform.position = Postacie[indicatorLocation].transform.position;
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Right")
        {
            Prawo();
        }
        if (gameObject.name == "Left")
        {
            Lewo();
        }
    }

    public void Prawo()
    {
        indicatorLocation++;
        if (indicatorLocation > 3)
        {
            indicatorLocation = 0;
        }
    }

    public void Lewo()
    {
        indicatorLocation--;
        if (indicatorLocation < 0)
        {
            indicatorLocation = 3;
        }
    }

    public void Enter()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
        CharacterChoiceController.indeksPostaci = indicatorLocation;
    }
}
