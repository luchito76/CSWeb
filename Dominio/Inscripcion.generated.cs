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
	public partial class Inscripcion
	{
		private int idInscripcion;
		public virtual int IdInscripcion
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
		
		private DateTime? fechaInscripcion;
		public virtual DateTime? FechaInscripcion
		{
			get
			{
				return this.fechaInscripcion;
			}
			set
			{
				this.fechaInscripcion = value;
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
		
		private int? idCursada;
		public virtual int? IdCursada
		{
			get
			{
				return this.idCursada;
			}
			set
			{
				this.idCursada = value;
			}
		}
		
		private bool? inscripcionAnulada;
		public virtual bool? InscripcionAnulada
		{
			get
			{
				return this.inscripcionAnulada;
			}
			set
			{
				this.inscripcionAnulada = value;
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
		
		private Cursada cursada;
		public virtual Cursada Cursada
		{
			get
			{
				return this.cursada;
			}
			set
			{
				this.cursada = value;
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
		
	}
}
#pragma warning restore 1591
