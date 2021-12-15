using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void All_Ones_game_score_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            var totalRolls = gameRules.MaxFramesCount * 2;
            Roll(game, 1, totalRolls);
            Assert.AreEqual(totalRolls, game.GetScore());
        }

        [TestMethod]
        public void One_Spare_game_score_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            var totalRolls = gameRules.MaxFramesCount * 2;
            Roll(game, 5, 2);
            Roll(game, 1, totalRolls - 2);
            Assert.AreEqual(29, game.GetScore());
        }

        [TestMethod]
        [DataRow(5, 9, 1, 1, 97)]
        public void Multiple_Consecutive_Spares_game_score_test(int consecutiveSparesCount, int spareFirstRoll, int spareSecondRoll, int normalRoll, int expected)
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            var totalRolls = gameRules.MaxFramesCount * 2;

            for (int i = 0; i < consecutiveSparesCount; i++)
            {
                Roll(game, spareFirstRoll, 1);
                Roll(game, spareSecondRoll, 1);
            }

            Roll(game, normalRoll, totalRolls - (consecutiveSparesCount * 2));
            Assert.AreEqual(expected, game.GetScore());
        }

        [TestMethod]
        public void One_Strike_game_score_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            var totalRolls = gameRules.MaxFramesCount * 2;
            Roll(game, 10, 1);
            Roll(game, 1, totalRolls - 2);
            Assert.AreEqual(30, game.GetScore());
        }

        [TestMethod]
        [DataRow(5, 1, 133)]
        public void Multiple_Consecutive_Strikes_game_score_test(int consecutiveStrikesCount, int roll, int expected)
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);
            var totalRolls = gameRules.MaxFramesCount * 2;

            for (int i = 0; i < consecutiveStrikesCount; i++)
            {
                Roll(game, 10, 1);
            }

            Roll(game, roll, totalRolls - (consecutiveStrikesCount * 2));
            Assert.AreEqual(expected, game.GetScore());
        }

        [TestMethod]
        public void All_Strikes_game_score_should_be_300_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);

            Roll(game, 10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void All_Spares_game_score_should_be_150_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);

            Roll(game, 5, 21);
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void All_Spares_And_Strikes_game_score_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);

            Roll(game, 5, 10);
            Roll(game, 10, 7);
            Assert.AreEqual(230, game.GetScore());
        }

        [TestMethod]
        public void Alternate_Spares_And_Strikes_game_score_test()
        {
            var gameRules = new GameRules();
            var game = new Game(gameRules);

            Roll(game, 5, 2);
            Roll(game, 10, 1);

            Roll(game, 5, 2);
            Roll(game, 10, 1);

            Roll(game, 5, 2);
            Roll(game, 10, 1);

            Roll(game, 5, 2);
            Roll(game, 10, 1);

            Roll(game, 5, 2);
            Roll(game, 10, 1);
            Roll(game, 5, 2);

            Assert.AreEqual(200, game.GetScore());
        }

        //GS
        [TestMethod]
        public void Score_should_be_valid_for_completed_game()
        {
            var game = new Game(new GameRules());
            game.Roll(7);
            game.Roll(2);
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            game.Roll(7);
            game.Roll(10);
            game.Roll(10);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);
            game.Roll(10);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            Assert.AreEqual(172, game.GetScore());
        }

        [TestMethod]
        public void Score_should_be_valid_for_completed_game_with_bonus_roll()
        {
            var game = new Game(new GameRules());
            game.Roll(7);
            game.Roll(2);
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            game.Roll(7);
            game.Roll(10);
            game.Roll(10);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);
            game.Roll(10);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            Assert.AreEqual(172, game.GetScore());
        }

        [TestMethod]
        public void Score_Should_Be_Valid()
        {
            var game = new Game(new GameRules());
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(5);
            game.Roll(5);
            game.Roll(7);
            game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9);
            game.Roll(0);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            Assert.AreEqual(187, game.GetScore());
        }

        [TestMethod]
        public void just_check()
        {
            var game = new Game(new GameRules());
            Roll(game, 0, 4);

            game.Roll(10);

            game.Roll(2);
            game.Roll(5);

            game.Roll(5);
            game.Roll(3);

            game.Roll(10);

            game.Roll(10);

            game.Roll(6);
            game.Roll(4);

            game.Roll(10);

            game.Roll(5);
            game.Roll(2);

            Assert.AreEqual(122, game.GetScore());
        }

        [TestMethod]
        public void just_check2()
        {
            var game = new Game(new GameRules());
            Roll(game, 0, 2);

            game.Roll(10);

            Roll(game, 0, 4);

            game.Roll(5);
            game.Roll(5);

            game.Roll(5);
            game.Roll(5);

            game.Roll(0);
            game.Roll(0);

            game.Roll(10);

            game.Roll(5);
            game.Roll(2);

            game.Roll(10);
            game.Roll(0);
            game.Roll(10);

            Assert.AreEqual(79, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}