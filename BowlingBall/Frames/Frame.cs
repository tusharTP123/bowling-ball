using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// Frame Base Class, Normal/Open Frames will be Frame
    /// </summary>
    internal class Frame : IFrame
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BowlingBall.Frame class
        /// </summary>
        /// <param name="frameIndex">The index of a frame</param>
        /// <param name="rolls">The collection of rolls for current frame</param>
        internal Frame(int frameIndex, IEnumerable<int> rolls)
        {
            FrameIndex = frameIndex;
            Rolls = rolls;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index of the frame
        /// </summary>
        public int FrameIndex { get; }

        /// <summary>
        /// The collection of rolls for current frame
        /// </summary>
        public IEnumerable<int> Rolls { get; }

        /// <summary>
        /// Score of Current Frame
        /// Total Pins Taken down by a player in current frame
        /// </summary>
        public int FrameScore => Rolls.Sum();

        /// <summary>
        /// Reference of the Next Frame for calculation of bonus in Spare/Strike Frames
        /// </summary>
        public IFrame NextFrame { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns Total Frame Score, in norma/open frame, it will be total pins taken down by a player
        /// </summary>
        /// <returns></returns>
        public virtual int GetTotalFrameScore()
        {
            return FrameScore;
        }

        #endregion Methods
    }
}