using Fusion;
using Fusion.Sockets;
using FusionExamples.FusionHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PairState
{
    Lobby,
    CreatingRoom,
    InRoom
}

public class LobbyManager : MonoBehaviour, INetworkRunnerCallbacks
{
    
    public PairState pairState = PairState.Lobby;

    private RunnerManager gameManager = null;

    [SerializeField] private PlayerNetworkData playerNetworkDataPrefab;

    [SerializeField] private RoomListPanel roomListPanel = null;
    [SerializeField] private CreateRoomPanel createRoomPanel = null;
    [SerializeField] private InRoomPanel inRoomPanel = null;

    private async void Start()
    {
        SetPairState(PairState.Lobby);

        gameManager = RunnerManager.Instance;

        gameManager.Runner.AddCallbacks(this);

        await JoinLobby(gameManager.Runner);
    }

    public async Task JoinLobby(NetworkRunner runner)
    {
        var result = await runner.JoinSessionLobby(SessionLobby.ClientServer);

        if (!result.Ok)
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
    }

    public void SetPairState(PairState newState)
    {
        pairState = newState;

        switch (pairState)
        {
            case PairState.Lobby:
                SetPanel(roomListPanel);
                break;
            case PairState.CreatingRoom:
                SetPanel(createRoomPanel);
                break;
            case PairState.InRoom:
                SetPanel(inRoomPanel);
                break;
        }
    }

    private void SetPanel(Ipanel panel)
    {
        roomListPanel.DisplayPanel(false);
        createRoomPanel.DisplayPanel(false);
        inRoomPanel.DisplayPanel(false);

        panel.DisplayPanel(true);
    }

    public async Task CreateRoom(string roomName, int maxPlayer)
    {
        var result = await gameManager.Runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Host,
            SessionName = roomName,
            PlayerCount = maxPlayer,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameManager.gameObject.AddComponent<NetworkSceneManagerDefault>(),
            //ObjectPool = gameManager.gameObject.AddComponent<FusionObjectPoolRoot>()
        });

        if (result.Ok)
            SetPairState(PairState.InRoom);
        else
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
    }

    public async Task JoinRoom(string roomName)
    {
        var result = await gameManager.Runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Client,
            SessionName = roomName,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameManager.gameObject.AddComponent<NetworkSceneManagerDefault>(),
            //ObjectPool = gameManager.gameObject.AddComponent<FusionObjectPoolRoot>()
        });

        if (result.Ok)
            SetPairState(PairState.InRoom);
        else
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        runner.Spawn(playerNetworkDataPrefab, Vector3.zero, Quaternion.identity, player);
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if (gameManager.PlayerList.TryGetValue(player, out PlayerNetworkData networkPlayerData))
        {
            runner.Despawn(networkPlayerData.Object);

            gameManager.PlayerList.Remove(player);
            gameManager.UpdatePlayerList();
        }
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        roomListPanel.UpdateRoomList(sessionList);
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
       
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

   

    
}
