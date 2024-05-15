using UnityEngine;
using UnityEngine.UI;

public class KeyCode : MonoBehaviour, Interactive
{
    public GameObject KeycodeUI;
    public GameObject salida;
    int currentIndex = 0;
    string currentCode = "";
    public string code = "1234";
    Image firstDigit;
    Image secondDigit;
    Image thirdDigit;
    Image fourthDigit;
    GameObject player;
    Camara camara;
    bool Interactive.active
    {
        get
        {
            return true;
        }
    }
    public void Interact()
    {
        OpenUI();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camara = player.GetComponentInChildren<Camara>();
        KeycodeUI.SetActive(false);
        firstDigit = KeycodeUI.transform.Find("Code").Find("First").GetComponent<Image>();
        secondDigit = KeycodeUI.transform.Find("Code").Find("Second").GetComponent<Image>();
        thirdDigit = KeycodeUI.transform.Find("Code").Find("Third").GetComponent<Image>();
        fourthDigit = KeycodeUI.transform.Find("Code").Find("Fourth").GetComponent<Image>();
    }
    void Update()
    {
        //Si tiene la UI abierta y se aleja del objeto, se cierra
        if (KeycodeUI.activeSelf && Vector3.Distance(transform.position, player.transform.position) > 1)
        {
            camara.HideCursor();
            Cancel();
            KeycodeUI.SetActive(false);
        }
        //Si esta abierta la UI y se presiona ESC se cierra
        if (KeycodeUI.activeSelf && Input.GetKeyDown(UnityEngine.KeyCode.Escape))
        {
            camara.HideCursor();
            Cancel();
            KeycodeUI.SetActive(false);
        }
    }
    void OpenUI()
    {
        camara.ShowCursor();
        KeycodeUI.SetActive(true);
    }
    public void AddNumber(int number)
    {
        //valida que el numero sea entre 0 y 9
        if (number < 0 || number > 9)
        {
            return;
        }
        if (currentIndex < 4)
        {
            if (currentIndex == 0)
            {
                firstDigit.sprite = Resources.Load<Sprite>("digits/segment_" + number);
            }
            if (currentIndex == 1)
            {
                secondDigit.sprite = Resources.Load<Sprite>("digits/segment_" + number);
            }
            if (currentIndex == 2)
            {
                thirdDigit.sprite = Resources.Load<Sprite>("digits/segment_" + number);
            }
            if (currentIndex == 3)
            {
                fourthDigit.sprite = Resources.Load<Sprite>("digits/segment_" + number);
            }
            currentCode += number.ToString();
            currentIndex++;
        }
        if (currentIndex >= 4)
        {
            CheckCode();
            return;
        }
    }
    public void Cancel()
    {
        currentIndex = 0;
        currentCode = "";
        firstDigit.sprite = Resources.Load<Sprite>("digits/segment_0");
        secondDigit.sprite = Resources.Load<Sprite>("digits/segment_0");
        thirdDigit.sprite = Resources.Load<Sprite>("digits/segment_0");
        fourthDigit.sprite = Resources.Load<Sprite>("digits/segment_0");
    }

    public void CheckCode()
    {
        //Se asegura que el codigo es de 4 digitos, rellena con ceros
        while (currentCode.Length < 4)
        {
            currentCode = "0" + currentCode;
        }
        if (currentCode.Equals(code))
        {
            salida.SetActive(false);
            camara.HideCursor();
            KeycodeUI.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Cancel();
        }
    }
}
