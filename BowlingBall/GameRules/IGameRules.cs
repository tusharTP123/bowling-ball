using System.Collections.Generic;

namespace BowlingBall
{
    public interface IGameRules
    {
        #region Properties

        /// <summary>
        /// Maximum Frames count per game
        /// </summary>
        int MaxFramesCount { get; set; }

        /// <summary>
        /// Maximum Rolls count for last Frame
        /// </summary>
        int MaxRollsCountForLastFrame { get; set; }

        /// <summary>
        /// Maximum Rolls count per Frame
        /// </summary>
        int MaxRollsCountPerFrame { get; set; }

        /// <summary>
        /// Maximum Rolls count per Strike
        /// </summary>
        int MaxRollsCountPerStrike { get; set; }

        /// <summary>
        /// Spare Bonus Rolls
        /// </summary>
        int SpareBonusRolls { get; set; }

        /// <summary>
        /// Strike Bonus Rolls
        /// </summary>

        int StrikeBonusRolls { get; set; }

        /// <summary>
        /// Total Pins
        /// </summary>
        int TotalPins { get; set; }

        #endregion Properties

        /// <summary>
        /// Returns Frame Type of the frame
        /// </summary>
        /// <param name="pins">Pins taken down in the frame</param>
        /// <returns>Returns type of the frame</returns>

        #region Methods

        FrameType GetFrameType(IEnumerable<int> pins);

        /// <summary>
        /// Get Maximum Number of roles allowed for the frame
        /// </summary>
        /// <param name="currentFrame">Frame Number</param>
        /// <param name="pins">Pins knocked in the frame</param>
        /// <returns>Maximum roles allowd to be thrown for the current frame</returns>

        int GetMaxRollsAllowedForCurrentFrame(int currentFrame, IEnumerable<int> pins);

        #endregion Methods
    }
}