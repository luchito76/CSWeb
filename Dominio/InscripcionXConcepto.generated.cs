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
	public partial class InscripcionXConcepto
	{
		private int idInscripcionXConcepto;
		public virtual int IdInscripcionXConcepto
		{
			get
			{
				return this.idInscripcionXConcepto;
			}
			set
			{
				this.idInscripcionXConcepto = value;
			}
		}
		
		private int? idInscripcion;
		public virtual int? IdInscripcion
		{
			get
			{
				return this.idInscripcion;
			}
			set
			{
				this.idInscripcion = value;
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
		
		private Inscripcion inscripcion;
		public virtual Inscripcion Inscripcion
		{
			get
			{
				return this.inscripcion;
			}
			set
			{
				this.inscripcion = value;
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
		
	}
}
#pragma warning restore 1591