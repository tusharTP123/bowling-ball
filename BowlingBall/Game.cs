using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// Represents a Game
    /// </summary>
    public class Game
    {
        #region Fields

        //Game Rules
        private readonly IGameRules _gameRules;

        //Frame Manager
        private readonly FrameManager _frameManager;

        //Frames per game
        private List<IFrame> _frames;

        //Temporarily storing pins for current frame
        private List<int> _tempPinsForCurrentFrame;

        //Frames counter
        private int _frameCounter = 1;

        //Rolls counter for Current Frame
        private int _rollCounterForCurrentFrame = 1;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BowlingBall.Game class
        /// </summary>
        /// <param name="gameRules">GameRules for the current game</param>
        public Game(IGameRules gameRules)
        {
            _gameRules = new GameRules();
            _frameManager = new FrameManager(gameRules);
            _frames = new List<IFrame>(_gameRules.MaxFramesCount);
            _tempPinsForCurrentFrame = new List<int>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Roll...
        /// </summary>
        /// <param name="pins">Number of pins knocked in a current role</param>
        public void Roll(int pins)
        {
            _tempPinsForCurrentFrame.Add(pins);

            if (_rollCounterForCurrentFrame == _gameRules.GetMaxRollsAllowedForCurrentFrame(_frameCounter, _tempPinsForCurrentFrame))
            {
                var frame = _frameManager.CreateFrame(_frameCounter, _tempPinsForCurrentFrame);

                _frameManager.SetNextFrameOfPreviousFrame(_frames, frame);

                _frames.Add(frame);

                ConfigureCountersForNextFrame();
            }
            else
                _rollCounterForCurrentFrame++;
        }

        /// <summary>
        /// Configure/Set Counters for next frame
        /// </summary>
        private void ConfigureCountersForNextFrame()
        {
            _frameCounter++;
            _rollCounterForCurrentFrame = 1;
            _tempPinsForCurrentFrame = new List<int>();
        }

        /// <summary>
        /// Returns the final score of the game.
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            int score = 0;
            foreach (var frame in _frames)
            {
                score += frame.GetTotalFrameScore();
            }
            return score;
        }

        #endregion Methods
    }
}