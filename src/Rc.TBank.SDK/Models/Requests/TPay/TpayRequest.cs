using System.Text.Json.Serialization;

namespace Rc.TBank.SDK.Models.Requests.TPay;

public class AgentData
{
    [JsonPropertyName("AgentSign")] public string AgentSign { get; set; }

    [JsonPropertyName("OperationName")] public string OperationName { get; set; }

    [JsonPropertyName("Phones")] public List<string> Phones { get; set; }

    [JsonPropertyName("ReceiverPhones")] public List<string> ReceiverPhones { get; set; }

    [JsonPropertyName("TransferPhones")] public List<string> TransferPhones { get; set; }

    [JsonPropertyName("OperatorName")] public string OperatorName { get; set; }

    [JsonPropertyName("OperatorAddress")] public string OperatorAddress { get; set; }

    [JsonPropertyName("OperatorInn")] public string OperatorInn { get; set; }
}

public class DATA
{
}

public class Item
{
    [JsonPropertyName("Name")] public string Name { get; set; }

    [JsonPropertyName("Price")] public int? Price { get; set; }

    [JsonPropertyName("Quantity")] public int? Quantity { get; set; }

    [JsonPropertyName("Amount")] public int? Amount { get; set; }

    [JsonPropertyName("PaymentMethod")] public string PaymentMethod { get; set; }

    [JsonPropertyName("PaymentObject")] public string PaymentObject { get; set; }

    [JsonPropertyName("Tax")] public string Tax { get; set; }

    [JsonPropertyName("Ean13")] public string Ean13 { get; set; }

    [JsonPropertyName("ShopCode")] public string ShopCode { get; set; }

    [JsonPropertyName("AgentData")] public AgentData AgentData { get; set; }

    [JsonPropertyName("SupplierInfo")] public SupplierInfo SupplierInfo { get; set; }
}

public class PaymentData
{
    [JsonPropertyName("TerminalKey")] public string TerminalKey { get; set; }

    [JsonPropertyName("Amount")] public int Amount { get; set; }

    [JsonPropertyName("OrderId")] public string OrderId { get; set; }

    [JsonPropertyName("Description")] public string Description { get; set; }

    [JsonPropertyName("DATA")] public DATA DATA { get; set; }

    [JsonPropertyName("Receipt")] public Receipt Receipt { get; set; }
}

public class PaymentInfo
{
    [JsonPropertyName("InfoEmail")] public string InfoEmail { get; set; }

    [JsonPropertyName("PaymentData")] public PaymentData PaymentData { get; set; }
}

public class PaymentItem
{
    [JsonPropertyName("container")] public string Container { get; set; }

    [JsonPropertyName("paymentInfo")] public PaymentInfo PaymentInfo { get; set; }
}

public class Payments
{
    [JsonPropertyName("Cash")] public int? Cash { get; set; }

    [JsonPropertyName("Electronic")] public int? Electronic { get; set; }

    [JsonPropertyName("AdvancePayment")] public int? AdvancePayment { get; set; }

    [JsonPropertyName("Credit")] public int? Credit { get; set; }

    [JsonPropertyName("Provision")] public int? Provision { get; set; }
}

public class PaymentSystems
{
    [JsonPropertyName("TinkoffPay")] public TinkoffPay TinkoffPaymentData { get; set; }
}

public class Receipt
{
    [JsonPropertyName("Items")] public List<Item> Items { get; set; }

    [JsonPropertyName("FfdVersion")] public string FfdVersion { get; set; }

    [JsonPropertyName("Email")] public string Email { get; set; }

    [JsonPropertyName("Phone")] public string Phone { get; set; }

    [JsonPropertyName("Taxation")] public string Taxation { get; set; }

    [JsonPropertyName("Payments")] public Payments Payments { get; set; }
}

public class TPayRequest
{
    [JsonPropertyName("container")] public string Container { get; set; }

    [JsonPropertyName("TerminalKey")] public string TerminalKey { get; set; }

    [JsonPropertyName("paymentInfo")] public PaymentInfo PaymentInfo { get; set; }

    [JsonPropertyName("paymentItems")] public List<PaymentItem> PaymentItems { get; set; }

    [JsonPropertyName("paymentSystems")] public PaymentSystems PaymentSystems { get; set; }
}

public class SupplierInfo
{
    [JsonPropertyName("Phones")] public List<string> Phones { get; set; }

    [JsonPropertyName("Name")] public string Name { get; set; }

    [JsonPropertyName("Inn")] public string Inn { get; set; }
}

public class TinkoffPay
{
    [JsonPropertyName("Amount")] public int Amount { get; set; }

    [JsonPropertyName("OrderId")] public string OrderId { get; set; }
}