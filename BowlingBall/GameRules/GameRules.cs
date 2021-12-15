using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// Game Rules for a current game
    /// </summary>
    public class GameRules : IGameRules
    {
        #region Properties

        /// <summary>
        /// Total Pins
        /// </summary>
        public int TotalPins { get; set; } = 10;

        /// <summary>
        /// Maximum Frames count per game
        /// </summary>
        public int MaxFramesCount { get; set; } = 10;

        /// <summary>
        /// Maximum Rolls count per Frame
        /// </summary>
        public int MaxRollsCountPerFrame { get; set; } = 2;

        /// <summary>
        /// Maximum Rolls count per Strike
        /// </summary>
        public int MaxRollsCountPerStrike { get; set; } = 1;

        /// <summary>
        /// Maximum Rolls count for last Frame
        /// </summary>
        public int MaxRollsCountForLastFrame { get; set; } = 3;

        /// <summary>
        /// Strike Bonus Rolls
        /// </summary>
        public int StrikeBonusRolls { get; set; } = 2;

        /// <summary>
        /// Spare Bonus Rolls
        /// </summary>
        public int SpareBonusRolls { get; set; } = 1;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get Maximum Number of roles allowed for the frame
        /// </summary>
        /// <param name="currentFrame">Frame Number</param>
        /// <param name="pins">Pins knocked in the frame</param>
        /// <returns>Maximum roles allowd to be thrown for the current frame</returns>
        public int GetMaxRollsAllowedForCurrentFrame(int currentFrame, IEnumerable<int> pins)
        {
            int maxRollsAllowed = MaxRollsCountPerFrame;

            //If current frame is last frame
            if (IsLastFrame(currentFrame))
            {
                if (IsStrike(pins) || IsSpare(pins))
                    maxRollsAllowed = MaxRollsCountForLastFrame;
            }
            else
            {
                if (IsStrike(pins))
                    maxRollsAllowed = MaxRollsCountPerStrike;
            }

            return maxRollsAllowed;
        }

        /// <summary>
        /// Returns Frame Type of the frame
        /// </summary>
        /// <param name="pins">Pins taken down in the frame</param>
        /// <returns>Returns type of the frame</returns>
        public FrameType GetFrameType(IEnumerable<int> pins)
        {
            if (IsStrike(pins))
                return FrameType.Strike;
            else if (IsSpare(pins))
                return FrameType.Spare;
            else
                return FrameType.Open;
        }

        /// <summary>
        /// Returns true/false depending upon the frame is the last frame of the game or not
        /// </summary>
        /// <param name="currentFrame">Frame Number</param>
        /// <returns>Returns true if the Last Frame, else false</returns>
        private bool IsLastFrame(int currentFrame)
        {
            return currentFrame == MaxFramesCount;
        }

        /// <summary>
        /// Returns true/false depending upon the frame is the Spare or not
        /// </summary>
        /// <param name="pins">Pins taken down in the frame</param>
        /// <returns>Returns true if the Spare, else false</returns>
        private bool IsSpare(IEnumerable<int> pins)
        {
            return pins.Count() >= MaxRollsCountPerFrame && pins.Take(MaxRollsCountPerFrame).Sum() == TotalPins;
        }

        /// <summary>
        /// Returns true/false depending upon the current frame is the Strike or not
        /// </summary>
        /// <param name="pins">Pins taken down in the frame</param>
        /// <returns>Returns true if the Strike, else false</returns>
        private bool IsStrike(IEnumerable<int> pins)
        {
            return pins.First() == TotalPins;
        }

        #endregion Methods
    }
}