namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PaymentIntentCreateOptions : PaymentIntentSharedOptions
    {
        [JsonProperty("capture_method")]
        public string CaptureMethod { get; set; }

        [JsonProperty("confirm")]
        public bool? Confirm { get; set; }

        [JsonProperty("confirmation_method")]
        public string ConfirmationMethod { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }
    }
}
