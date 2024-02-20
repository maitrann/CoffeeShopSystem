using PayPal.Api;
using PayPal.Api.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Utilities;
using WebGrease.Activities;
using WebMVC_CoffeeShopSystem.Dao;
using WebMVC_CoffeeShopSystem.Repositories;
using WebMVC_CoffeeShopSystem.Utilities;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class CheckoutController : Controller
    {
        dynamic callCartDao = CartDao.Instance;
        dynamic callVoucherDao = VoucherDao.Instance;
        dynamic callInvoiceDao = InvoiceDao.Instance;
        private Payment payment;

        // GET: Checkout
        public ActionResult Index(string lsCartCheckout, string lsIdVoucherSupp, string idVoucherCafe, string priceTotal)
        {
            if (lsCartCheckout != null)
            {
                int idAccount = 7;
                ViewBag.lsCartCheckout = callCartDao.GetCartCheckout(idAccount, lsCartCheckout);
                ViewBag.lsVoucherOfSupp = callVoucherDao.GetVoucherByMulIdVoucher(lsIdVoucherSupp);
                ViewBag.voucherCafe = callVoucherDao.GetVoucherByMulIdVoucher(idVoucherCafe);
                ViewBag.strIdCart = lsCartCheckout;
                ViewBag.priceTotal = priceTotal;
                return View();
            }
            else
            {
                return Redirect("/Cart");
            }
        }
        public ActionResult PaymentWithPaypal(string priceTotal, string address, string idVoucherS, string idVoucherA, string lsIdCart,
            string lsIdSupplier, string priceSupp, string priceAdmin, string fee, string Cancel = null)
        {
            //ObjectInvoice callHandle = new ObjectInvoice();
            var callHandle = handleObjectInvoice(priceTotal, address, idVoucherS, idVoucherA, lsIdCart, lsIdSupplier, priceSupp, priceAdmin, fee);
            string guid;
            //getting the apiContext
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal
                //Payer Id will be returned when payment proceeds or click to pay
                string payerId = Request.Params["PayerID"];

                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist
                    //it is returned by the create function call of the payment class

                    // Creating a payment
                    // baseURL is the url on which paypal sendsback the data.
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                "/CheckOut/PaymentWithPayPal?";

                    //here we are generating guid for storing the paymentID received in session
                    //which will be used in the payment execution

                    guid = Convert.ToString((new Random()).Next(100000));

                    //CreatePayment function gives us the payment approval url
                    //on which payer is redirected for paypal account payment

                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, priceTotal);

                    //get links returned from paypal in response to Create function call

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = null;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    // saving the paymentID in the key guid
                    Session.Add(guid, createdPayment.id);

                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment

                    guid = Request.Params["guid"];

                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                    //If executed payment failed then we will show payment failure message to user
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return Redirect("http://localhost:52519");
                    }
                }
            }
            catch (Exception ex)
            {
                return Redirect("http://localhost:52519");
            }

            //on successful payment, show success page to user.
            callHandle.modelInvoice.idPayment = Session[guid] as string;
            callInvoiceDao.InsertInvoice(callHandle);
            return RedirectToAction("Index", "Orders", new { checkout = "done" });
        }
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private ObjectInvoice handleObjectInvoice(string priceTotal, string address, string idVoucherS, string idVoucherA, string lsIdCart,
            string lsIdSupplier, string priceSupp, string priceAdmin, string fee)
        {
            ObjectInvoice objectInvoice = new ObjectInvoice();
            objectInvoice.modelInvoice.idAccount = 7;
            objectInvoice.modelInvoice.address = address;
            objectInvoice.modelInvoice.totalPrice = priceTotal.AsDecimal();
            //objectInvoice.modelInvoice.idPayment = Session[guid] as string;
            objectInvoice.modelInvoice.idVoucherS = idVoucherS;
            objectInvoice.modelInvoice.idVoucherA = idVoucherA;
            objectInvoice.modelInvoice.isStatus = 0;

            string[] strIdCart = lsIdCart.Split(',');
            foreach (var idCart in strIdCart)
            {
                InvoiceDetail detail = new InvoiceDetail();
                detail.idCart = (idCart.AsInt());
                detail.isStatus = 0;
                objectInvoice.modelInvoiceDetail.Add(detail);
            }

            string[] strIdSupp = lsIdSupplier.Split(',');
            string[] strPriceSupp = priceSupp.Split(',');
            for (int i = 0; i < strIdSupp.Length; i++)
            {
                InvoiceSupplier invoiceSupplier = new InvoiceSupplier();
                invoiceSupplier.idSupplier = strIdSupp[i].AsInt();
                for (global::System.Int32 j = i; j < strPriceSupp.Length;)
                {
                    invoiceSupplier.price = strPriceSupp[j].AsDecimal();
                }
                invoiceSupplier.status = 0;
                objectInvoice.modelInvoiceSupplier.Add(invoiceSupplier);
            }

            objectInvoice.modelInvoiceAdmin.price = priceAdmin.AsDecimal();
            objectInvoice.modelInvoiceAdmin.status = 0;
            objectInvoice.modelInvoiceAdmin.feeService = fee.AsDecimal();
            return objectInvoice;
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string priceTotal)
        {

            //create itemlist and add item objects to it
            //var itemList = new ItemList() { items = new List<Item>() };

            //itemList.items.Add(new Item()
            //{
            //    name = item2.titleProd,
            //    currency = "USD",
            //    price = item2.UnitPrice.ToString(),
            //    quantity = item2.Amount.ToString(),
            //    sku = "sku"
            //});


            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details
            //var calcSubTotal = 0;
            //foreach (var item in lstCheckout)
            //{
            //    foreach (var item2 in item.cartViews)
            //    {
            //        calcSubTotal += (Convert.ToInt16(item2.UnitPrice) * Convert.ToInt16(item2.Amount));
            //    }
            //}
            var details = new Details()
            {
                //tax = fee,
                //subtotal = itemList.items.Sum(s => Convert.ToInt16(s.price) * Convert.ToInt16(s.quantity)).ToString(),
                //subtotal = calcSubTotal.ToString(),
            };

            //Final amount with details
            var amount = new Amount()
            {
                currency = "USD",
                //total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.subtotal)).ToString(), // Total must be equal to sum of tax, shipping and subtotal.
                total = priceTotal,
                details = details
            };

            var transactionList = new List<Transaction>();
            // Adding description about the transaction
            transactionList.Add(new Transaction()
            {
                description = "Transaction Payment Cafena with Paypal",
                invoice_number = Convert.ToString((new Random()).Next(100000)), //Generate an Invoice No
                amount = amount,
                //item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
        }

    }
}