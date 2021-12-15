using System.Collections.Generic;

namespace BowlingBall
{
    /// <summary>
    /// Represents a Frame of a game.
    /// </summary>
    public interface IFrame
    {
        #region Properties

        /// <summary>
        /// Index of the frame
        /// </summary>
        int FrameIndex { get; }

        /// <summary>
        /// Frame Score / Total pins taken down in the current frame
        /// </summary>
        int FrameScore { get; }

        /// <summary>
        /// Collection of rolls thrown in the current frame
        /// </summary>
        IEnumerable<int> Rolls { get; }

        /// <summary>
        /// Reference of the Next Frame for calculation of bonus in Spare/Strike Frames
        /// </summary>
        IFrame NextFrame { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns total score of the frame including bonus (if the current frame is Spare/Strike Frame)
        /// </summary>
        /// <returns></returns>
        int GetTotalFrameScore();

        #endregion Methods
    }
}