using UnityEngine;
using UnityEngine.UI;

public class Konami : MonoBehaviour
{
    public GameObject receiver;
    public string message = "Code complete.";

    //Setup
    private int index = 0;
    GameObject[] konamiObjects;

    //Sets time constraints on code input
    public float timeBetweenInput = 1f;
    public float totalTime = 10f;

    //Variables counting time passed
    private float timeSinceLastInput = 0f;
    private float totalTimePassed = 0f;
    
    [SerializeField]
    private KeyCode[] konami = new KeyCode[]
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.B,
        KeyCode.A
    };

    void Start()
    {
        konamiObjects = GameObject.FindGameObjectsWithTag("Konami");
        HideKonami();
    }

    void Update()
    {
        this.timeSinceLastInput += Time.deltaTime;
        this.totalTimePassed += Time.deltaTime;

        if (timeSinceLastInput >= timeBetweenInput || totalTimePassed >= totalTime)
        {
            this.index = 0;
        }

        KeyCode? currentKey = null;
        currentKey = HandleKeyboard();

        CheckKey(currentKey);
    }

    private KeyCode? HandleKeyboard()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(this.konami[index]))
            {
                return this.konami[index];
            }
        }

        return null;
    }

    private void CheckKey(KeyCode? currentKey)
    {
        if (currentKey != null && currentKey.Value == this.konami[index])
        {
            if (this.index == 0)
            {
                this.totalTimePassed = 0f;
            }

            this.timeSinceLastInput = 0f;
            this.index++;

            if (this.index >= this.konami.Length)
            {
                Debug.Log("Code complete.");

                if (this.receiver != null)
                {
                    this.receiver.SendMessage(this.message, SendMessageOptions.DontRequireReceiver);
                }

                this.index = 0;
                ShowKonami();
            }
        } else if (currentKey != null)
        {
            this.index = 0;
        }
    }

    public void ShowKonami()
    {
        foreach(GameObject g in konamiObjects)
        {
            g.SetActive(true);
        }

        Debug.Log("Showed Konami.");
    }

    void HideKonami()
    {
        foreach(GameObject g in konamiObjects)
        {
            g.SetActive(false);
        }

        Debug.Log("Hid Konami.");
    }

}