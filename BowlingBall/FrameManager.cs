using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    /// <summary>
    /// FrameManager class to initialize different frames such as Open, Strike, Spare
    /// </summary>
    internal class FrameManager
    {
        #region Fields

        private readonly IGameRules _gameRules;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BowlingBall.FrameManager class
        /// </summary>
        /// <param name="gameRules">GameRules for the current game</param>
        internal FrameManager(IGameRules gameRules)
        {
            _gameRules = gameRules;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Create a new frame (Open, Strike, Spare) depending upon total pins taken down and current frame
        /// </summary>
        /// <param name="frameIndex">Current Frame Number</param>
        /// <param name="pins">Total Pins taken down in current frame</param>
        /// <returns></returns>
        internal IFrame CreateFrame(int frameIndex, IEnumerable<int> pins)
        {
            FrameType frameType = _gameRules.GetFrameType(pins);

            switch (frameType)
            {
                case FrameType.Open:
                    return new Frame(frameIndex, pins);

                case FrameType.Spare:
                    return new SpareFrame(_gameRules, frameIndex, pins);

                case FrameType.Strike:
                    return new StrikeFrame(_gameRules, frameIndex, pins);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Sets Next Frame reference for the previous frame
        /// </summary>
        /// <param name="frames">Total frames of a game</param>
        /// <param name="frame">Current Frame</param>
        internal void SetNextFrameOfPreviousFrame(List<IFrame> frames, IFrame frame)
        {
            if (frame == null || frames == null)
                return;

            if (frames.LastOrDefault() == null)
                return;

            frames.Last().NextFrame = frame;
        }

        #endregion Methods
    }
}