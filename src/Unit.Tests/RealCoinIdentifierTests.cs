using System;
using CoinSorter.CoinChecks;
using CoinSorter.CoinIdentifiers;
using CoinSorter.Coins;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
	[TestFixture]
	public class RealCoinIdentifierTests
	{
		private ICoinCheck _coinCheck;
		private double _expectedMass;
		private RealCoinIdentifier _realCoinIdentifier;
		private ICoinIdentifier _successor;
		private string _value;

		[SetUp]
		public void SetUp() {
			_successor = MockRepository.GenerateStub<ICoinIdentifier>();
			_coinCheck = MockRepository.GenerateStub<ICoinCheck>();
			_expectedMass = 10;
			_value = "One florin";
			_realCoinIdentifier = new RealCoinIdentifier(_successor, _coinCheck, new CoinInput {Mass = _expectedMass}, _value);
		}

		[Test]
		public void Should_call_check_coin() {
			var coinInput = new CoinInput {Mass = 20};

			_realCoinIdentifier.Identify(coinInput);

			_coinCheck.AssertWasCalled(cc => cc.CheckCoin(Arg<CoinInput>.Is.Equal(coinInput), Arg<CoinInput>.Matches(x => Math.Abs(x.Mass - _expectedMass) < 0.0001)));
		}

		[Test]
		public void Should_call_successor_if_coin_check_fails() {
			var coinInput = new CoinInput {Mass = 20};
			_coinCheck.Stub(cc => cc.CheckCoin(null, null)).IgnoreArguments().Return(false);

			_realCoinIdentifier.Identify(coinInput);

			_successor.AssertWasCalled(s => s.Identify(coinInput));
		}

		[Test]
		public void Should_return_correct_value_if_coin_check_passes() {
			var coinInput = new CoinInput {Mass = 20};
			_coinCheck.Stub(cc => cc.CheckCoin(null, null)).IgnoreArguments().Return(true);

			Coin output = _realCoinIdentifier.Identify(coinInput);

			Assert.That(output.Value, Is.EqualTo(_value));
		}

		[Test]
		public void Should_return_value_from_successor() {
			var coinInput = new CoinInput {Mass = 20};
			_coinCheck.Stub(cc => cc.CheckCoin(null, null)).IgnoreArguments().Return(false);
			var successorCoin = new Coin {Value = _value};
			_successor.Stub(s => s.Identify(null)).IgnoreArguments().Return(successorCoin);

			Coin output = _realCoinIdentifier.Identify(coinInput);

			Assert.That(output, Is.EqualTo(successorCoin));
		}
	}
}