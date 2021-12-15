using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    /// <summary>
    /// Represents the spare frame
    /// </summary>
    internal class SpareFrame : Frame
    {
        #region Fields

        private readonly IGameRules _gameRules;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BowlingBall.SpareFrame class
        /// </summary>
        /// <param name="gameRules">Game Rules for the current game</param>
        /// <param name="frameIndex">The index of a frame</param>
        /// <param name="rolls">The collection of rolls for current frame</param>

        internal SpareFrame(IGameRules gameRules, int frameIndex, IEnumerable<int> rolls) : base(frameIndex, rolls)
        {
            _gameRules = gameRules;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns the total frame score including bonus
        /// </summary>
        /// <returns>Total frame score including bonus</returns>
        public override int GetTotalFrameScore()
        {
            return this.GetBonusRollsScore(_gameRules.SpareBonusRolls, FrameScore);
        }

        #endregion Methods
    }
}