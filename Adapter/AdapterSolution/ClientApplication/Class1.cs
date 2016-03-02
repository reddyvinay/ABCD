using System;

using CTS.Demo.Training.Libraries.Core;
using CTS.Demo.Training.Libraries.OrderSubmitters;

using CTS.Demo.Training.Libraries.Adapters;

namespace CTS.Demo.Training.Applications 
{
	public class OrderClient 
	{
		public static void Main ( string[] args ) 
		{
			IOrderSubmitter orderSubmitterObject = new ERPApplicationOrderSubmitter ();
			
			PurchaseOrder poObject = new PurchaseOrder();
			poObject.PORefNumber = "X82830";
			poObject.PODate = "2004-04-05";
			poObject.CustomerName = "CTS";
			poObject.POTotal = 7000;

			Console.WriteLine ( "Status (ERP) : " + 
				orderSubmitterObject.SubmitPO ( poObject ) );
			
			orderSubmitterObject = new FinanceApplicationOrderSubmitter();
			Console.WriteLine ( "Status (FINANCE) : " + 
				orderSubmitterObject.SubmitPO ( poObject ) );

			Console.WriteLine ( "Utilizing SAP Adapter ... ");
			orderSubmitterObject = new SAPAdapter ();
			Console.WriteLine ( "Status (EXTERNAL) " + 
				orderSubmitterObject.SubmitPO ( poObject ) );

			Console.ReadLine();
		}
	}
}