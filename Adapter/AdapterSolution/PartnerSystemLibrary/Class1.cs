using System;

namespace Externals.Demo.Training.Libraries.Core 
{
	public class PurchaseOrder 
	{
		public string PORefNumber;
		public string PODate;
		public int DiscountExpected;
		public int POTotal;
	}

	public class POAcknowledgement 
	{
		public PurchaseOrder PO;
		public string POARefNumber;
		public string POADate;
	}

	public interface IOrderSubmitter 
	{
		POAcknowledgement SubmitOrder ( PurchaseOrder aPO );
	}

	public class SAPOrderSubmitter : IOrderSubmitter 
	{
		public SAPOrderSubmitter () {}
		public POAcknowledgement SubmitOrder ( PurchaseOrder aPOObject ) 
		{
			Console.WriteLine ( "Submitting Order to SAP System ... ");
			Console.WriteLine ( aPOObject.ToString() );
			
			POAcknowledgement poaObject = new POAcknowledgement();
			poaObject.PO = aPOObject;
			poaObject.POARefNumber = aPOObject.PORefNumber + "-Ack";
			poaObject.POADate = DateTime.Now.ToString();

			return poaObject;
		}
	}
}