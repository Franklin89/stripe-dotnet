namespace StripeTests
{
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class ChargeTest : BaseStripeTest
    {
        public ChargeTest(StripeMockFixture stripeMockFixture)
            : base(stripeMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/charges/ch_123");
            var charge = JsonConvert.DeserializeObject<Charge>(json);
            Assert.NotNull(charge);
            Assert.IsType<Charge>(charge);
            Assert.NotNull(charge.Id);
            Assert.Equal("charge", charge.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            // TODO: fix stripe-mock to properly expand application_fee
            string[] expansions =
            {
              "application",
              "balance_transaction",
              "customer",
              "dispute",
              "invoice",
              "on_behalf_of",
              "order",
              "review",
              "source_transfer",
              "transfer",
            };

            string json = this.GetFixture("/v1/charges/ch_123", expansions);
            var charge = JsonConvert.DeserializeObject<Charge>(json);
            Assert.NotNull(charge);
            Assert.IsType<Charge>(charge);
            Assert.NotNull(charge.Id);
            Assert.Equal("charge", charge.Object);

            Assert.NotNull(charge.Application);
            Assert.Equal("application", charge.Application.Object);

            Assert.NotNull(charge.BalanceTransaction);
            Assert.Equal("balance_transaction", charge.BalanceTransaction.Object);

            Assert.NotNull(charge.Customer);
            Assert.Equal("customer", charge.Customer.Object);

            Assert.NotNull(charge.Dispute);
            Assert.Equal("dispute", charge.Dispute.Object);

            Assert.NotNull(charge.Invoice);
            Assert.Equal("invoice", charge.Invoice.Object);

            Assert.NotNull(charge.OnBehalfOf);
            Assert.Equal("account", charge.OnBehalfOf.Object);

            Assert.NotNull(charge.Order);
            Assert.Equal("order", charge.Order.Object);

            Assert.NotNull(charge.Review);
            Assert.Equal("review", charge.Review.Object);

            Assert.NotNull(charge.SourceTransfer);
            Assert.Equal("transfer", charge.SourceTransfer.Object);

            Assert.NotNull(charge.Transfer);
            Assert.Equal("transfer", charge.Transfer.Object);
        }
    }
}
