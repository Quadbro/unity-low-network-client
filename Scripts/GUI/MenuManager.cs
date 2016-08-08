using System.Collections.Generic;
using System.Net;
using Game.Core;
using Game.Network.Packets.Request;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [Header("Menu pages")]
    public GameObject page_MainMenu;

    public GameObject page_ConnectMenu;
    public GameObject page_Options;

    [Header("Connect menu")]
    public InputField input_Ip;

    public InputField input_Port;
    public InputField input_Username;
    public InputField input_Password;
    public Button btn_Join;

    // Navigation stuff
    private List<GameObject> pageQueue;

    public void Start () {
        // Initialize some variables
        pageQueue = new List<GameObject>();
        // Set default values
        GoToNextPage(page_MainMenu);
        //input_Ip.text = "37.229.254.242";
        input_Ip.text = "127.0.0.1";
        input_Port.text = "44445";
        input_Username.text = "SomeUser";
        input_Password.text = "SomePassword";
    }

    public void Update () {
    }

    public void GoToNextPage (GameObject next) {
        pageQueue.Add(next);
        int currIndex = pageQueue.Count - 2;
        int nextIndex = pageQueue.Count - 1;

        if (currIndex >= 0) {
            GameObject currPage = pageQueue[currIndex];
            GameObject nextPage = pageQueue[nextIndex];
            SwitchPage(currPage, nextPage);
        } else if (nextIndex == 0) {
            GameObject nextPage = pageQueue[nextIndex];
            nextPage.SetActive(true);
        } else {
            return;
        }
    }

    public void GoToPrevPage () {
        int currIndex = pageQueue.Count - 1;
        int prevIndex = pageQueue.Count - 2;

        if (currIndex < 1 || prevIndex < 0) {
            return;
        } else {
            GameObject currPage = pageQueue[currIndex];
            GameObject prevPage = pageQueue[prevIndex];
            SwitchPage(currPage, prevPage);
            pageQueue.RemoveAt(currIndex);
        }
    }

    public void SwitchPage (GameObject deactivatePage, GameObject activatePage) {
        deactivatePage.SetActive(false);
        activatePage.SetActive(true);
    }

    public void OnButtonBack () {
        GoToPrevPage();
    }

    // Main menu section
    public void OnButtonConnect () {
        GoToNextPage(page_ConnectMenu);
        CheckJoinData();
    }

    public void OnButtonOptions () {
        GoToNextPage(page_Options);
    }

    public void OnButtonQuit () {
        Application.Quit();
    }

    // Connect menu section
    public void OnButtonJoin () {
        string ip = input_Ip.text;
        int port = int.Parse(input_Port.text);
        string username = input_Username.text;
        string password = input_Password.text;

        GameManager.network.Connect(ip, port);
        GameManager.network.Send(new ConnectionRequest(username, password));
    }

    public void CheckJoinData () {
        // Get data
        string ip = input_Ip.text;
        string port = input_Port.text;
        string username = input_Username.text;
        string password = input_Password.text;

        // Check ip
        IPAddress address;
        bool isValidIp = System.Net.IPAddress.TryParse(ip, out address);

        // Check epty strings
        if (ip != "" && port != "" && username != "" && password != "" && isValidIp) {
            btn_Join.interactable = true;
        } else {
            btn_Join.interactable = false;
        }
    }

    public void OnButtonDisconnect () {
        GameManager.network.Disconnect();
    }
}