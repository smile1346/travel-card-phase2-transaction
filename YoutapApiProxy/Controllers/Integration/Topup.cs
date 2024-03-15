using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;
using Examples;

namespace Controllers;

readonly partial struct Integration
{
    [SwaggerRequestExample(typeof(GeneralTransactionRequestModel.Root), typeof(GeneralTransactionRequestExample))]
    [SwaggerOperation(Summary = "Deposit / Withdrawal", Description = @"Performs a transaction that deposits money from the merchant's balance into the customer's account. Used when the customer gives physical cash to the merchant in order to top up their digital wallet.

This is the same operation (i.e. the requests are almost the same) as the withdrawal. The paymentType in the transactionDetails defines which direction the money goes.

C2MD: Customer to Merchant Deposit. The transaction goes from the merchant to the customer.

C2MW: Customer to Merchant Withdrawal. the transaction goes from the customer to the merchant.")]
    public static IResult Topup(GeneralTransactionRequestModel.Root payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

}
