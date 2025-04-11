using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private string playerName = "Player";

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            // Initialize local player
            playerName = "Player " + OwnerClientId;
            ChatUIManager.Instance.SetLocalPlayer(this);
        }

        // Register player with UI manager
        ChatUIManager.Instance.AddPlayer(OwnerClientId, playerName);
    }

    public override void OnNetworkDespawn()
    {
        // Remove player from UI manager
        ChatUIManager.Instance.RemovePlayer(OwnerClientId);
    }

    [ServerRpc]
    public void SendMessageServerRpc(string message, ServerRpcParams rpcParams = default)
    {
        var senderId = rpcParams.Receive.SenderClientId;
        ReceiveMessageClientRpc(message, senderId);
    }

    [ClientRpc]
    public void ReceiveMessageClientRpc(string message, ulong senderId)
    {
        // Removed the IsOwner check so all clients process messages
        ChatUIManager.Instance.DisplayMessage(senderId, message);
    }
}