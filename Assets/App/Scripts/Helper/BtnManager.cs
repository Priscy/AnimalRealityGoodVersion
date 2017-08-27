using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {
    public UIButton btnIzq;
    public UIButton btnDer;
    public GameObject hand;
    private int state = 0;
    public UILabel paso1;
    public UILabel instrucc1;
    public UILabel paso2;
    public UILabel istrucc2;

	// Use this for initialization
	void Start () {
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable() {
        EventDelegate.Add(btnIzq.onClick, izqPressed);
        EventDelegate.Add(btnDer.onClick, derPressed);
    }

    void izqPressed() {
        switch (state) {
            case 0:
                SceneManager.LoadScene("01.Menu", LoadSceneMode.Additive);
                break;
            case 1:
                hand.gameObject.SetActive(false);
                paso2.gameObject.SetActive(false);
                istrucc2.gameObject.SetActive(false);
                paso1.gameObject.SetActive(true);
                instrucc1.gameObject.SetActive(true);
                state = 0;
                break;
            
        }
    }

    void derPressed() {
        switch (state) { 
            case 0:
                hand.gameObject.SetActive(true);
                paso1.gameObject.SetActive(false);
                instrucc1.gameObject.SetActive(false);
                paso2.gameObject.SetActive(true);
                istrucc2.gameObject.SetActive(true);
                state = 1;
                break;
            case 1:
                hand.gameObject.SetActive(false);
                SceneManager.LoadScene("03.Main", LoadSceneMode.Single);
                break;

        }
    
    }

}
