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
	public partial class Pago
	{
		private int idPago;
		public virtual int IdPago
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
		
		private int? idAlumno;
		public virtual int? IdAlumno
		{
			get
			{
				return this.idAlumno;
			}
			set
			{
				this.idAlumno = value;
			}
		}
		
		private DateTime? fechaPago;
		public virtual DateTime? FechaPago
		{
			get
			{
				return this.fechaPago;
			}
			set
			{
				this.fechaPago = value;
			}
		}
		
		private Alumno alumno;
		public virtual Alumno Alumno
		{
			get
			{
				return this.alumno;
			}
			set
			{
				this.alumno = value;
			}
		}
		
		private IList<DetallePago> detallePagos = new List<DetallePago>();
		public virtual IList<DetallePago> DetallePagos
		{
			get
			{
				return this.detallePagos;
			}
		}
		
	}
}
#pragma warning restore 1591
