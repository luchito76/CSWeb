#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Dominio;

namespace Dominio	
{
	public partial class DetallePago
	{
		private int idDetallePago;
		public virtual int IdDetallePago
		{
			get
			{
				return this.idDetallePago;
			}
			set
			{
				this.idDetallePago = value;
			}
		}
		
		private int? idPago;
		public virtual int? IdPago
		{
			get
			{
				return this.idPago;
			}
			set
			{
				this.idPago = value;
			}
		}
		
		private decimal? saldo;
		public virtual decimal? Saldo
		{
			get
			{
				return this.saldo;
			}
			set
			{
				this.saldo = value;
			}
		}
		
		private decimal? valorConcepto;
		public virtual decimal? ValorConcepto
		{
			get
			{
				return this.valorConcepto;
			}
			set
			{
				this.valorConcepto = value;
			}
		}
		
		private int? idMes;
		public virtual int? IdMes
		{
			get
			{
				return this.idMes;
			}
			set
			{
				this.idMes = value;
			}
		}
		
		private int? idDescuento;
		public virtual int? IdDescuento
		{
			get
			{
				return this.idDescuento;
			}
			set
			{
				this.idDescuento = value;
			}
		}
		
		private decimal? descuentoAplicado;
		public virtual decimal? DescuentoAplicado
		{
			get
			{
				return this.descuentoAplicado;
			}
			set
			{
				this.descuentoAplicado = value;
			}
		}
		
		private int? idConcepto;
		public virtual int? IdConcepto
		{
			get
			{
				return this.idConcepto;
			}
			set
			{
				this.idConcepto = value;
			}
		}
		
		private string observaciones;
		public virtual string Observaciones
		{
			get
			{
				return this.observaciones;
			}
			set
			{
				this.observaciones = value;
			}
		}
		
		private decimal? valorAPagar;
		public virtual decimal? ValorAPagar
		{
			get
			{
				return this.valorAPagar;
			}
			set
			{
				this.valorAPagar = value;
			}
		}
		
		private decimal? valorConceptoConDescuento;
		public virtual decimal? ValorConceptoConDescuento
		{
			get
			{
				return this.valorConceptoConDescuento;
			}
			set
			{
				this.valorConceptoConDescuento = value;
			}
		}
		
		private Concepto concepto;
		public virtual Concepto Concepto
		{
			get
			{
				return this.concepto;
			}
			set
			{
				this.concepto = value;
			}
		}
		
		private Pago pago;
		public virtual Pago Pago
		{
			get
			{
				return this.pago;
			}
			set
			{
				this.pago = value;
			}
		}
		
		private Descuento descuento;
		public virtual Descuento Descuento
		{
			get
			{
				return this.descuento;
			}
			set
			{
				this.descuento = value;
			}
		}
		
		private Me me;
		public virtual Me Me
		{
			get
			{
				return this.me;
			}
			set
			{
				this.me = value;
			}
		}
		
	}
}
#pragma warning restore 1591
