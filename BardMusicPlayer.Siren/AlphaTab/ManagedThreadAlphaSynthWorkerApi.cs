﻿/*
 * Copyright(c) 2021 Daniel Kuschny
 * Licensed under the MPL-2.0 license. See https://github.com/CoderLine/alphaTab/blob/develop/LICENSE for full license information.
 */

using System;
using System.Collections.Concurrent;
using System.Threading;
using BardMusicPlayer.Siren.AlphaTab.Audio.Synth;
using BardMusicPlayer.Siren.AlphaTab.Util;

namespace BardMusicPlayer.Siren.AlphaTab;

internal class ManagedThreadAlphaSynthWorkerApi : AlphaSynthWorkerApiBase
{
    private readonly Action<Action> _uiInvoke;
    private readonly Thread _workerThread;
    private BlockingCollection<Action> _workerQueue;
    private CancellationTokenSource _workerCancellationToken;
    private readonly ManualResetEventSlim _threadStartedEvent;

    public ManagedThreadAlphaSynthWorkerApi(ISynthOutput output, LogLevel logLevel, Action<Action> uiInvoke)
        : base(output, logLevel)
    {
        _uiInvoke = uiInvoke;

        _threadStartedEvent      = new ManualResetEventSlim(false);
        _workerQueue             = new BlockingCollection<Action>();
        _workerCancellationToken = new CancellationTokenSource();

        _workerThread = new Thread(DoWork)
        {
            IsBackground = true
        };
        _workerThread.Start();

        _threadStartedEvent.Wait();
        _workerQueue.Add(Initialize);
        _threadStartedEvent.Dispose();
        _threadStartedEvent = null;
    }

    public override void Destroy()
    {
        _workerCancellationToken.Cancel();
        _workerThread.Join();
    }

    protected override void DispatchOnUiThread(Action action)
    {
        _uiInvoke(action);
    }

    private bool CheckAccess()
    {
        return Thread.CurrentThread == _workerThread;
    }

    protected override void DispatchOnWorkerThread(Action action)
    {
        if (CheckAccess())
        {
            action();
        }
        else
        {
            _workerQueue.Add(action);
        }
    }

    private void DoWork()
    {
        try
        {
            _threadStartedEvent.Set();
            while (_workerQueue.TryTake(out var action, Timeout.Infinite, _workerCancellationToken.Token))
            {
                if (_workerCancellationToken.IsCancellationRequested)
                {
                    break;
                }

                action();
            }
        }
        catch (OperationCanceledException)
        {
            // Ignored
        }
    }
}