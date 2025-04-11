using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChatUIManager : MonoBehaviour
{
    public static ChatUIManager Instance { get; private set; }

    [SerializeField] private TMP_InputField messageInput;
    [SerializeField] private Button sendButton;
    [SerializeField] private Transform playersListContent;
    [SerializeField] private Transform chatContent;
    [SerializeField] private GameObject playerListItemPrefab;
    [SerializeField] private GameObject chatMessagePrefab;

    private Dictionary<ulong, string> players = new Dictionary<ulong, string>();
    private PlayerController localPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
        messageInput.onEndEdit.AddListener((text) => { if (Input.GetKeyDown(KeyCode.Return)) SendMessage(); });
    }

    public void SetLocalPlayer(PlayerController player)
    {
        localPlayer = player;
    }

    public void AddPlayer(ulong clientId, string playerName)
    {
        if (players.ContainsKey(clientId)) return;

        players.Add(clientId, playerName);
        UpdatePlayersList();
    }

    public void RemovePlayer(ulong clientId)
    {
        if (!players.ContainsKey(clientId)) return;

        players.Remove(clientId);
        UpdatePlayersList();
    }

    private void UpdatePlayersList()
    {
        // Clear existing items
        foreach (Transform child in playersListContent)
        {
            Destroy(child.gameObject);
        }

        // Add current players
        foreach (var player in players)
        {
            var item = Instantiate(playerListItemPrefab, playersListContent);
            item.GetComponent<TMP_Text>().text = player.Value;
        }
    }

    public void DisplayMessage(ulong senderId, string message)
    {
        if (!players.TryGetValue(senderId, out var senderName))
        {
            senderName = "Player " + senderId;
        }

        var chatItem = Instantiate(chatMessagePrefab, chatContent);
        chatItem.GetComponent<TMP_Text>().text = $"{senderName}: {message}";
    }

    private void SendMessage()
    {
        if (string.IsNullOrWhiteSpace(messageInput.text) || localPlayer == null) return;

        localPlayer.SendMessageServerRpc(messageInput.text);
        messageInput.text = "";
        messageInput.ActivateInputField();
    }
}