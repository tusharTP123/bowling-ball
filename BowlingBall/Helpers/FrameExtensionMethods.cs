using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    /// <summary>
    /// Frame Extenstion Methods Class
    /// </summary>
    public static class FrameExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Returns Bonus Rolls score for Strike/Spare Frames
        /// </summary>
        /// <param name="frame">The frame for which Bonus score needs to be found</param>
        /// <param name="bonusRollsCount">Bonus rolls for the frame</param>
        /// <param name="totalFrameScore">Total frame score</param>
        /// <param name="bonusRollsUsed">Bonus rolls used</param>
        /// <returns></returns>
        public static int GetBonusRollsScore(this IFrame frame, int bonusRollsCount, int totalFrameScore, int bonusRollsUsed = 0)
        {
            var nextFrame = frame.NextFrame;

            if (nextFrame == null)
                return totalFrameScore;

            foreach (var roll in nextFrame.Rolls)
            {
                if (bonusRollsUsed >= bonusRollsCount)
                    break;
                else
                {
                    totalFrameScore += roll;
                    bonusRollsUsed++;
                }
            }

            if (bonusRollsUsed == bonusRollsCount)
                return totalFrameScore;
            else
                return nextFrame.GetBonusRollsScore(bonusRollsCount, totalFrameScore, bonusRollsUsed);
        }

        #endregion Methods
    }
}