using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Highscore
{
    public string imie;
    public int wynik;
    public string adres;
}

public class LeaderBoard : MonoBehaviour
{
    public Text Username;
    public Text Mail;

    public static string currentName;
    public static int currentScore;
    public static string currentMail;

    public static string plik;
    public static string highscores;
    public static string [] nowyPlik;
    public static string[] words;
    public static Highscore[] currentLeaderBoard = new Highscore[50];
    public static Highscore[] loadedLeaderBoard = new Highscore[50];


    // Start is called before the first frame update
    void Start()
    {
        var input = GameObject.Find("Imie").GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        var input2 = GameObject.Find("Email").GetComponent<InputField>();
        var se2 = new InputField.SubmitEvent();
        se2.AddListener(SubmitName2);
        input2.onEndEdit = se2;



        Odczyt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NowyWynik()
    {
        int score = GameController.score;
        bool pozycjaZnaleziona = false;
        if (currentLeaderBoard != null)
        {
            for (int i = 0; i < 50; i++)
            {
                if (score > currentLeaderBoard[i].wynik && pozycjaZnaleziona == false)
                {
                    for (int j = 48; j >= i; j--)
                    {
                        currentLeaderBoard[j + 1].wynik = currentLeaderBoard[j].wynik;
                        currentLeaderBoard[j + 1].imie = currentLeaderBoard[j].imie;
                        currentLeaderBoard[j + 1].adres = currentLeaderBoard[j].adres;

                    }
                    currentLeaderBoard[i].wynik = score;
                    currentLeaderBoard[i].imie = currentName;
                    currentLeaderBoard[i].adres = currentMail;
                    pozycjaZnaleziona = true;
                }
            }

            for (int i = 0; i < 50; i++)
            {
                nowyPlik[3 * i] = currentLeaderBoard[i].imie;
                nowyPlik[3 * i + 1] = currentLeaderBoard[i].wynik.ToString();
                nowyPlik[3 * i + 2] = currentLeaderBoard[i].adres;
            }
            for (int i = 0; i < nowyPlik.Length; i++)
            {
                highscores = highscores + nowyPlik[i] + "\n";
            }
        }


        }

        public void Zapis()
    {
        StartCoroutine(sendTextToFile());
    }

    public void Odczyt()
    {
        StartCoroutine(getTextFromFile());
        Debug.Log("Twoja Stara" + plik);
        //words = plik.Split('\n');
        //for(int i=0; i < 149; i++)
        //{
        //    if(i%3 == 0)
        //    {
        //        loadedLeaderBoard[i].imie = words[i];

        //    }else if(i%3 == 1)
        //    {
        //        loadedLeaderBoard[i].wynik = int.Parse(words[i]);
        //    }else if(i%3 == 2)
        //    {
        //        loadedLeaderBoard[i].adres = words[i];
        //    }
        //}

        //currentLeaderBoard = loadedLeaderBoard;
    }

    IEnumerator sendTextToFile()
    {
        bool successful = true;

        WWWForm form = new WWWForm();
        form.AddField("imie", currentName);
        form.AddField("mail", currentMail);
        form.AddField("score", GameController.score);
        WWW www = new WWW("https://misjadreamkast.pl/leaderboard.php", form);

        yield return www;
        if (www.error != null)
        {
            successful = false;
        }
        else
        {
            successful = true;
        }
    }

    IEnumerator getTextFromFile()
    {
        bool successful = true;

        WWWForm form = new WWWForm();
        WWW www = new WWW("https://misjadreamkast.pl/leaderboard.php", form);

        yield return www;
        if (www.error != null)
        {
            Debug.Log("Klapa");
            successful = false;
        }
        else
        {
            Debug.LogWarning("SEX" + www.text);
            plik = www.text;
            successful = true;
        }
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        currentName = arg0;
    }

    private void SubmitName2(string arg0)
    {
        Debug.Log(arg0);
        currentMail = arg0;
    }

    public void DestroyGowno()
    {
        GameObject.Find("Imie").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Email").transform.localScale = new Vector3(0, 0, 0);
    }
}
