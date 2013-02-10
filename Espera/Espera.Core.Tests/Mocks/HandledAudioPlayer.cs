﻿using Espera.Core.Audio;
using System;
using System.Threading;

namespace Espera.Core.Tests.Mocks
{
    /// <summary>
    /// A <see cref="AudioPlayer"/> mock that raises the <see cref="AudioPlayer.SongFinished"/>
    /// event when the <see cref="ManualResetEvent"/> is set, after <see cref="Play"/> is called.
    /// </summary>
    internal class HandledAudioPlayer : AudioPlayer
    {
        private readonly ManualResetEvent handle;

        public HandledAudioPlayer(ManualResetEvent handle)
        {
            this.handle = handle;
        }

        public override TimeSpan CurrentTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override IObservable<AudioPlayerState> PlaybackState
        {
            get { throw new NotImplementedException(); }
        }

        public override IObservable<TimeSpan> TotalTime
        {
            get { throw new NotImplementedException(); }
        }

        public override float Volume { get; set; }

        public override void Dispose()
        {
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Play()
        {
            handle.WaitOne();

            this.OnSongFinished();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}