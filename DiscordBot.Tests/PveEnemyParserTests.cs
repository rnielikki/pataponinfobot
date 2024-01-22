﻿
using DiscordBot.Database;
using DiscordBot.Database.DataTypes;

namespace DiscordBot.Tests
{
    public class PveEnemyParserTests
    {
        private readonly Dictionary<string, PveEnemyInfo> _enemyInfo;
        public PveEnemyParserTests()
        {
            _enemyInfo = new TsvParser().Parse<PveEnemyInfo>("data/PVE.tsv", StringComparer.OrdinalIgnoreCase);
        }
        [Fact]
        public void PveParseString_EnemyTypeTest()
        {
            var record = _enemyInfo["Chicken"];
            Assert.Equal(EnemyType.Dragon, record.EnemyType);
        }
        [Fact]
        public void PveParseString_EnemyResistanceTest()
        {
            var record = _enemyInfo["Fish"];
            Assert.Equal(1.2f, record.LightTaken, 0.001);
        }
        [Fact]
        public void PveParseString_WeaknessOrderTest()
        {
            Assert.Single(_enemyInfo["Fish"].GetWeaknesses());
            Assert.Equal(3, _enemyInfo["Fish"].GetStrengthes().Length);
            Assert.Equal(1.5f, _enemyInfo["Bear"].GetWeaknesses()[0].Value, 0.001);
            Assert.Equal(AttackElement.Sound, _enemyInfo["Cat"].GetStrengthes()[0].Key);
            Assert.Equal(0.75, _enemyInfo["Cat"].GetStrengthes()[1].Value);
        }
    }
}