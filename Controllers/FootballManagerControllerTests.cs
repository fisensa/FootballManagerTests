using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballManager.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using FootballManager.Models;

namespace FootballManager.Controllers.Tests
{
    [TestClass()]
    public class FootballManagerControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var controller = new FootballManagerController();
            List<PlayerTeam> playerTeams = (List<PlayerTeam>)controller.Get();

            NUnit.Framework.Assert.IsNotNull(playerTeams);
        }

        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, false)]
        [DataRow(4, true)]
        [DataRow(2, false)]
        public void GetTest1(int id, bool isEmpty)
        {

            var controller = new FootballManagerController();
            List<PlayerTeam> playerTeams = (List<PlayerTeam>)controller.Get(id);
            NUnit.Framework.Assert.AreEqual((playerTeams.Count == 0), isEmpty);
        }

        [DataTestMethod]
        [DataRow(0, "testname", "testsurname", 34, PlayerPosition.CENTRE_MIDFIELDER, "2019/03/12", false)]
        [DataRow(1, "testname1", "testsurname1", 34, PlayerPosition.CENTRE_BACK, "2019/04/12", true)]
        public void TestInsertPlayer(int teamId, string playerName, string playerSurname, int playerNumber, PlayerPosition playerPosition, string playerBirthRate, bool expected)
        {
            var controller = new FootballManagerController();
            var player = new Player { FKTeamId = teamId, PlayerName = playerName, PlayerSurname = playerSurname, PlayerNumber = playerNumber, PlayerPosition = playerPosition, PlayerBirthDate = playerBirthRate };
            bool result = controller.InsertPlayer(player);
            NUnit.Framework.Assert.AreEqual(result, expected);



        }

        [DataTestMethod]
        [DataRow(0, 0, false)]
        [DataRow(1, 2, true)]
        [DataRow(1, 1, true)]
        [DataRow(2, 25, false)]
        [DataRow(3, 1, true)]
        public void TestMovePlayer(long playerId, int teamId, bool isMoved)
        {

            var controller = new FootballManagerController();
            bool result = controller.MovePlayerToTeam(playerId, teamId);
            NUnit.Framework.Assert.AreEqual(result, isMoved);
        }

        [DataTestMethod]
        [DataRow("CT", "Ama", 2, true)]
        [DataRow("CT", "Ama", 0, false)]
        [DataRow("CT", "Ama", 1, true)]
        public void TestAddTeam(string teamLocation, string teamName, int stadiumId, bool isNull)
        {
            var controller = new FootballManagerController();
            Team team = new Team { TeamLocation = teamLocation, TeamName = teamName, FKStadiumId = stadiumId };
            Team addedTeam = controller.AddTeam(team);
            bool result = (addedTeam != null);
            NUnit.Framework.Assert.AreEqual(result, isNull);
        }

    }
}