using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //sprite management
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int indeksPostaci;
    public int doceloweKropelki;
    public static int __doceloweKropelki;

    //boosty
    [HideInInspector]
    private static int boostTimer;
    private int crusherMode;
    public static string boostName;
    public static bool boostOn;

    public static int mnoznik = 1;



    //wynik i liczba ¿yæ
    public static int livesLeft = 7;
    public static int score = 0;
    public static int premiaCzasowa;

    public static GameObject[] coins;
    public static GameObject[] mixtures;
    public static GameObject[] guziki;

    public static int liczbaKropelek = 0;
    public static int buteleczka = 0;

    //kontrola animacji
    public Animator animator;

    //czas gry
    public int sredniCzas;
    private static int _sredniCzas;
    private static int _bufor;
    public static int time;
    private static int _framecount;

    public GameObject itemKluczowy;
    public GameObject drzwi;

    //zarzadzanie rozgrywka
    public static bool gameOn;
    public static bool gameReady;
    public int numerPoziomu;
    public static int _numerPoziomu;
    private static string _kolejnyPoziom;
    public static bool zmianaPoziomu = false;

    public static GameObject szklanka;



    // Start is called before the first frame update
    void Start()
    {
        guziki = GameObject.FindGameObjectsWithTag("ButtonGameOver");
        foreach (GameObject guzik in guziki)
        {
            guzik.transform.localScale = new Vector3(0, 0, 0);
        }
        _numerPoziomu = numerPoziomu;
        _kolejnyPoziom = (_numerPoziomu + 1).ToString();

        __doceloweKropelki = doceloweKropelki;

        GameObject.Find("Level").GetComponent<Text>().text = "Level: " + _numerPoziomu.ToString();

        CharacterSelection();
        animator.SetInteger("idPostaci", indeksPostaci);
        
        time = 0;
        _framecount = 0;
        _sredniCzas = sredniCzas;

        if(_numerPoziomu != 1)
        {
            BigAssText.WyswietlKomunikatCzasowy("POZIOM " + _numerPoziomu.ToString() + "\nPremia punktowa: " + premiaCzasowa.ToString(), 2);
        }
        else
        {
            BigAssText.WyswietlKomunikatCzasowy("POZIOM " + _numerPoziomu.ToString(), 2);
        }
        coins = GameObject.FindGameObjectsWithTag("ObjectCoin");
        //mixtures = GameObject.FindGameObjectsWithTag("ObjectMixture");

        szklanka = GameObject.Find("SuperStrength");


        if(_numerPoziomu == 6)
        {
            PlayerPrefs.SetInt("score6", score);
            PlayerPrefs.SetInt("buteleczka6", buteleczka);
            //livesLeft = livesLeft + 5;
        }
        if (_numerPoziomu == 11)
        {
            PlayerPrefs.SetInt("score11", score);
            PlayerPrefs.SetInt("buteleczka11", buteleczka);
            //livesLeft = livesLeft + 5;
        }
        if (_numerPoziomu == 16)
        {
            PlayerPrefs.SetInt("score16", score);
            PlayerPrefs.SetInt("buteleczka16", buteleczka);
            //livesLeft = livesLeft + 5;
        }
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning(_numerPoziomu);
        //
        if(zmianaPoziomu == true)
        {
            zmianaPoziomu = false;
            //string nazwaSceny = "Level_" + _kolejnyPoziom;
            //StartCoroutine(LoadYourAsyncScene(nazwaSceny));
        }

        //przygotowanie
        if(gameReady == true)
        {
            
            if (_bufor == 0)
            {
                if (Input.GetKeyDown("space") || GuzikSkok.skok)
                {
                    gameOn = true;
                    gameReady = false;
                    BigAssText.WyswietlKomunikatCzasowy("GO", 2);
                }
            
            }
            else
            {
                _bufor--;
            }
        }

        //jezeli gra sie toczy
        if (gameOn == true)
        {
            _framecount++;
            time = _framecount / 50;
        }

        //ZbieranieMonet();

        //booster dziala
        if (boostOn)
        {
            BoostCounter.BoostOn(boostName, boostTimer);
            boostTimer--;
            if(boostTimer <= 0)
            {
                Boost(boostName, false);
            }
        }

        //smierciucha
        if (livesLeft <= 0)
        {
            GameOver();
        }

        //koniec poziomu
        if(WarunekUkonczenia(itemKluczowy, liczbaKropelek, doceloweKropelki) == true)
        {
            drzwi.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            drzwi.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public static void CheckPointLoad(int poziom)
    {
        if(poziom == 6)
        {
            SceneManager.LoadScene("Level_6", LoadSceneMode.Single);
            zmianaPoziomu = true;
            if (boostName != null)
            {
                Boost(boostName, false);
            }

            liczbaKropelek = 0;
            _framecount = 0;
            time = 0;
            gameOn = false;
            score = PlayerPrefs.GetInt("score6");
            buteleczka = PlayerPrefs.GetInt("buteleczka6");
        }
        if (poziom == 11)
        {
            SceneManager.LoadScene("Level_11", LoadSceneMode.Single);
            zmianaPoziomu = true;
            if (boostName != null)
            {
                Boost(boostName, false);
            }

            liczbaKropelek = 0;
            _framecount = 0;
            time = 0;
            gameOn = false;
            score = PlayerPrefs.GetInt("score11");
            buteleczka = PlayerPrefs.GetInt("buteleczka11");
        }
        if (poziom == 16)
        {
            SceneManager.LoadScene("Level_16", LoadSceneMode.Single);
            zmianaPoziomu = true;
            if (boostName != null)
            {
                Boost(boostName, false);
            }

            liczbaKropelek = 0;
            _framecount = 0;
            time = 0;
            gameOn = false;
            score = PlayerPrefs.GetInt("score16");
            buteleczka = PlayerPrefs.GetInt("buteleczka16");
        }
        if (poziom == 1)
        {
            livesLeft = 7;
            score = 0;
            buteleczka = 0;
            liczbaKropelek = 0;

            Array.Clear(InventoryPrzechowalnia.obiekty, 0, 12);
            SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
        }
    }

    public static void ResetGry()
    {
        livesLeft = 7;
        score = 0;
        buteleczka = 0;
        liczbaKropelek = 0;

        Array.Clear(InventoryPrzechowalnia.obiekty, 0, 12);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }


    public static void StartGry()
    {
        BigAssText.WyswietlKomunikat("Nacisnij spacje lub skok, aby rozpoczac poziom");
        gameReady = true;
        _bufor = 20;
        Debug.LogWarning("POWINNO KURWA DZIALAC JA PIERDOLE");
        GameObject.Find("Button").SetActive(false);
    }

    public static bool WarunekUkonczenia(GameObject _itemKluczowy, int _liczbaKropelek, int _doceloweKropelki)
    {
        bool itemCollected = Inventory.CheckIfElement(_itemKluczowy);
        if(itemCollected == true && _liczbaKropelek >= _doceloweKropelki)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void CharacterSelection()
    {
        indeksPostaci = CharacterChoiceController.indeksPostaci;
        spriteRenderer.sprite = sprites[indeksPostaci];
    }

    public static void Score(int punkty)
    {
        score = score + punkty * mnoznik;
        buteleczka = buteleczka + punkty*mnoznik;
        if(buteleczka >= 48)
        {
            BigAssText.WyswietlKomunikatCzasowy("Nowe zycie!", 2);
            livesLeft++;
            buteleczka = buteleczka - 48;
        }
    }

    public static void Kropelka()
    {
        liczbaKropelek++;
    }

    public static void Death()
    {
        livesLeft = livesLeft - 1;
        //score = 0;
        //liczbaKropelek = 0;
        
        //foreach (GameObject coin in coins)
        //{
        //    coin.SetActive(true);
        //}

        //foreach (GameObject mixture in mixtures)
        //{
        //    mixture.SetActive(true);
        //}
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("CharacterEnemy");
        //foreach (GameObject enemy in enemies)
        //{
        //    Enemy skrypt;
        //    skrypt = enemy.GetComponent<Enemy>();
        //    skrypt.Resurrection();
        //}
        //itemCollected = false;
    }

    public static void GameOver()
    {
        gameOn = false;
        BigAssText.WyswietlKomunikat("GAME OVER\nScore: " + score.ToString());
        
        foreach(GameObject guzik in guziki)
        {
            guzik.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public static void NextLevel()
    {
        if(_numerPoziomu == 20)
        {
            Finish();
        }
        else
        {
            SceneManager.LoadScene("Level_" + _kolejnyPoziom, LoadSceneMode.Single);
            zmianaPoziomu = true;
            if (boostName != null)
            {
                Boost(boostName, false);
            }
            //GameObject.Find("Powitanie").GetComponent<TextLevel>().enabled = false;
            //GameObject.Find("Powitanie").GetComponent<TextLevel>().enabled = true;
            liczbaKropelek = 0;
            _framecount = 0;
            int _premiaCzasowa = 0;
            if (time < _sredniCzas)
            {
                _premiaCzasowa = (_sredniCzas - time) * 2 + 2* livesLeft;
            }
            premiaCzasowa = _premiaCzasowa;
            time = 0;
            gameOn = false;
            Score(premiaCzasowa);
        }
    }

    public static void Menu()
    {
        livesLeft = 7;
        score = 0;
        buteleczka = 0;
        liczbaKropelek = 0;

        Array.Clear(InventoryPrzechowalnia.obiekty, 0, 12);
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

    public static void Finish()
    {
        gameOn = false;
        int _premiaCzasowa = 0;
        if (time < _sredniCzas)
        {
            _premiaCzasowa = (_sredniCzas - time) * 2 + 3 * livesLeft;
        }
        premiaCzasowa = _premiaCzasowa;
        Score(premiaCzasowa);
        BigAssText.WyswietlKomunikat("WYGRALES, BRAWO!\nMISJA DREAMKAST WYKONANA!\nScore: " + score.ToString());

        foreach (GameObject guzik in guziki)
        {
            guzik.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public static void Boost(string name, bool onOff)
    {
        boostName = name;

        if(name == "SuperJump")
        {
            if (onOff)
            {
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                Player.jumpForce = 4000;
                boostTimer = 1000;
                boostOn = true;
            }
            else
            {
                Player.jumpForce = 3000;
                boostOn = false;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
            }

        }

        if (name == "SuperStrength")
        {
            if (onOff)
            {
                score = score - 20;
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                boostTimer = 1000;
                boostOn = true;
            }
            else
            {
                boostOn = false;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
                szklanka.SetActive(true);
            }

        }

        if (name == "PigeonDestroyer")
        {
            if (onOff)
            {
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                boostTimer = 3000;
                Player.armed = true;
                boostOn = true;
            }
            else
            {
                Player.armed = false;
                boostOn = false;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
            }

        }

        if (name == "AntMode")
        {
            if (onOff)
            {
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                boostTimer = 4000;                
                boostOn = true;
            }
            else
            {
                boostOn = false;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
            }

        }

        if (name == "DoubleScore")
        {
            if (onOff)
            {
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                boostTimer = 2000;
                mnoznik = 2;
                boostOn = true;
            }
            else
            {
                boostOn = false;
                mnoznik = 1;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
            }

        }

        if (name == "SuperSpeed")
        {
            if (onOff)
            {
                BigAssText.WyswietlKomunikatCzasowy(name, 2);
                boostTimer = 2000;
                Player.walkSpeed = 1200;
                boostOn = true;
            }
            else
            {
                boostOn = false;
                Player.walkSpeed = 600;
                BoostCounter.BoostOff();
                //BigAssText.WyswietlKomunikatCzasowy(name + " wygasl", 2);
            }

        }
    }

    public static IEnumerator Foo(float time)
    {
        // Do something
        yield return new WaitForSeconds(time);  // Wait three seconds
                                              // Do something else
    }

    //public static IEnumerator LoadYourAsyncScene(string nazwaSceny)
    //{
    //    // Set the current Scene to be able to unload it later
    //    Scene currentScene = SceneManager.GetActiveScene();

    //    // The Application loads the Scene in the background at the same time as the current Scene.
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nazwaSceny, LoadSceneMode.Additive);

    //    // Wait until the last operation fully loads to return anything
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }

    //    // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
    //    for(int i = 0; i<12; i++)
    //    {
    //        if (Inventory.inventory[i] != null)
    //        {
    //            SceneManager.MoveGameObjectToScene(Inventory.inventory[i].obiekt, SceneManager.GetSceneByName(nazwaSceny));
    //        }
    //    }

    //    // Unload the previous Scene
    //    SceneManager.UnloadSceneAsync(currentScene);
    //}
}
