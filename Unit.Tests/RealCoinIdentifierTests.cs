using Console;
using Console.CoinChecks;
using Console.CoinIdentifiers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
	[TestFixture]
	public class RealCoinIdentifierTests
	{
		private RealCoinIdentifier _realCoinIdentifier;
		private ICoinIdentifier _successor;
		private ICoinCheck _coinCheck;
		private double _expectedMass;
		private string _value;

		[SetUp]
		public void SetUp() {
			_successor = MockRepository.GenerateStub<ICoinIdentifier>();
			_coinCheck = MockRepository.GenerateStub<ICoinCheck>();
			_expectedMass = 10;
			_value = "One florin";
			_realCoinIdentifier = new RealCoinIdentifier(_successor, _coinCheck, _expectedMass, _value);
		}

		[Test]
		public void Should_call_check_coin() {
			var coinInput = new CoinInput {Mass = 20};
			_realCoinIdentifier.Identify(coinInput);

			_coinCheck.AssertWasCalled(cc => cc.CheckCoin(Arg<CoinInput>.Is.Equal(coinInput), Arg<CoinInput>.Matches(x => x.Mass == _expectedMass)));
		}
	}
}