using System;

namespace CTS.Demo.Training.Libraries.Core 
{
	[Serializable()]
	public class PurchaseOrder 
	{
		private string _poRefNumber;
		private string _poDate;
		private string _customerName;
		private int _poTotal;

		public PurchaseOrder () {}
		
		public string PORefNumber 
		{
			get
			{
				return this._poRefNumber;
			}
			set
			{
				this._poRefNumber = value;
			}
		}

		public string PODate 
		{
			get
			{
				return this._poDate;
			}
			set
			{
				this._poDate = value;
			}
		}

		public string CustomerName 
		{
			get
			{
				return this._customerName;
			}
			set 
			{
				this._customerName = value;
			}
		}

		public int POTotal 
		{
			get
			{
				return this._poTotal;
			}
			set
			{
				this._poTotal = value;
			}
		}


		public override string ToString()
		{
			string DISPLAY_FORMAT = @"{0}:{1}:{2}:{3}";
			return string.Format ( DISPLAY_FORMAT, this._poRefNumber, 
				this._poDate, this._customerName, this._poTotal );
		}
	}
}