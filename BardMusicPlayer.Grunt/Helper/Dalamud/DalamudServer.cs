﻿/*
 * Copyright(c) 2021 MoogleTroupe
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

#nullable enable
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using H.Pipes;
using H.Pipes.AccessControl;
using H.Pipes.Args;

namespace BardMusicPlayer.Grunt.Helper.Dalamud;

internal class DalamudServer : IDisposable
{
    private readonly PipeServer<string> _pipe;
    private readonly ConcurrentDictionary<int, string> _clients;

    /// <summary>
    /// 
    /// </summary>
    internal DalamudServer()
    {
        _clients                 =  new ConcurrentDictionary<int, string>();
        _pipe                    =  new PipeServer<string>("BardMusicPlayer-Grunt-Dalamud");
        _pipe.ClientConnected    += OnConnected;
        _pipe.ClientDisconnected += OnDisconnected;
        _pipe.MessageReceived    += OnMessage;
#pragma warning disable CA1416
        _pipe.AllowUsersReadWrite();
#pragma warning restore CA1416
        Start();
    }

    internal async void Start()
    {
        if (_pipe.IsStarted) return;
        await _pipe.StartAsync();
    }

    internal async void Stop()
    {
        if (!_pipe.IsStarted) return;
        await _pipe.StopAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pid"></param>
    /// <returns></returns>
    internal bool IsConnected(int pid) => _clients.ContainsKey(pid) && _pipe.ConnectedClients.FirstOrDefault(x => x.PipeName == _clients[pid] && x.IsConnected) is not null;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pid"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    internal bool SendChat(int pid, string text)
    {
        if (!IsConnected(pid)) return false;
        _pipe.ConnectedClients.FirstOrDefault(x => x.PipeName == _clients[pid] && x.IsConnected)?.WriteAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
        return true;
    }

    private void OnMessage(object? sender, ConnectionMessageEventArgs<string?> e)
    {
        if (string.IsNullOrEmpty(e.Message)) return;

        var fields = e.Message?.Split(':') ?? Array.Empty<string>();

        if (fields.Length != 3) return;

        if (!int.TryParse(fields[0], out var pid)) return;

        switch (fields[1])
        {
            case "scanned" when bool.Parse(fields[2]):
                _clients[pid] = e.Connection.PipeName;
                Debug.WriteLine($"Dalamud client Id {e.Connection.PipeName} sig scanned");
                break;
            case "chatted" when bool.Parse(fields[2]):
                Debug.WriteLine($"Dalamud client Id {e.Connection.PipeName} chatted");
                break;
        }
    }

    private void OnDisconnected(object? sender, ConnectionEventArgs<string> e)
    {
        if (_clients.Values.Contains(e.Connection.PipeName)) _clients.TryRemove(_clients.FirstOrDefault(x => x.Value == e.Connection.PipeName).Key, out _);
        Debug.WriteLine($"Dalamud client Id {e.Connection.PipeName} disconnected");
    }

    private static void OnConnected(object? sender, ConnectionEventArgs<string> e)
    {
        Debug.WriteLine($"Dalamud client Id {e.Connection.PipeName} connected");
    }

    public void Dispose()
    {
        try
        {
            Stop();
            _pipe.MessageReceived    -= OnMessage;
            _pipe.ClientConnected    -= OnDisconnected;
            _pipe.ClientDisconnected -= OnConnected;
            _pipe.DisposeAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Dalamud error: {ex.Message}");
        }
        _clients.Clear();
    }
}