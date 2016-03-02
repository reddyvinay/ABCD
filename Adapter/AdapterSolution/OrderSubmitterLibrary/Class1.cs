using System;
using CTS.Demo.Training.Libraries.Core;

namespace CTS.Demo.Training.Libraries.OrderSubmitters 
{
	public interface IOrderSubmitter 
	{
		bool SubmitPO ( PurchaseOrder purchaseOrderObject );
	}

	public class ERPApplicationOrderSubmitter : IOrderSubmitter
	{
		public ERPApplicationOrderSubmitter () {}
		public bool SubmitPO ( PurchaseOrder purchaseOrderObject ) 
		{
			Console.WriteLine ( "Submitting purchaseOrder to ERP ... ");
			Console.WriteLine ( "ERP : " + purchaseOrderObject.ToString() );

			return true;
		}
	}

	public class FinanceApplicationOrderSubmitter : IOrderSubmitter 
	{
		public FinanceApplicationOrderSubmitter () {}
		public bool SubmitPO ( PurchaseOrder purchaseOrderObject ) 
		{
			Console.WriteLine ( "Opening a secured gate-way to finance application .. ");
			Console.WriteLine ( "Submitting purchaseOrder to Finance ... ");
			Console.WriteLine ( "FINANCE : " + purchaseOrderObject.ToString() );

			if ( purchaseOrderObject.POTotal >= 5000 ) 
				return true;

			return false;
		}
	}
}