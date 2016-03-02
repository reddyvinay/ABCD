using System;

using CTS.Demo.Training.Libraries.Core;
using CTS.Demo.Training.Libraries.OrderSubmitters;

using Externals.Demo.Training.Libraries.Core;

using InternalOrderSubmitter = 
	CTS.Demo.Training.Libraries.OrderSubmitters.IOrderSubmitter;
using InternalPurchaseOrder = CTS.Demo.Training.Libraries.Core.PurchaseOrder;

using ExternalOrderSubmitter = Externals.Demo.Training.Libraries.Core.IOrderSubmitter;
using ExternalPurchaseOrder = Externals.Demo.Training.Libraries.Core.PurchaseOrder;

namespace CTS.Demo.Training.Libraries.Adapters 
{
	public abstract class BaseAdapter : InternalOrderSubmitter 
	{
		public abstract bool SubmitPO ( InternalPurchaseOrder poObject );
	}

	public class SAPAdapter : BaseAdapter 
	{
		public SAPAdapter () {}
		public override bool SubmitPO(InternalPurchaseOrder poObject)
		{
			ExternalPurchaseOrder epoObject = POHelper.GetExternalPO ( poObject );
			ExternalOrderSubmitter orderSubmitterObject = 
				new SAPOrderSubmitter();
			POAcknowledgement poaObject = orderSubmitterObject.SubmitOrder ( epoObject );
			if ( poaObject.POARefNumber.Equals ( poObject.PORefNumber + "-Ack" ) )
			{
				return true;
			}

			return false;
		}
	}

	public class POHelper 
	{
		public static ExternalPurchaseOrder GetExternalPO ( 
			InternalPurchaseOrder poObject ) 
		{
			ExternalPurchaseOrder epoObject = new ExternalPurchaseOrder();
			epoObject.PORefNumber = poObject.PORefNumber;
			epoObject.PODate = poObject.PODate;
			epoObject.POTotal = poObject.POTotal;

			// Define the Logic on how to obtain discount expected value!
			epoObject.DiscountExpected = 0;

			return epoObject;
		}
	}
}