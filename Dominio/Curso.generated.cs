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
	public partial class Curso
	{
		private int idCurso;
		public virtual int IdCurso
		{
			get
			{
				return this.idCurso;
			}
			set
			{
				this.idCurso = value;
			}
		}
		
		private string nombre;
		public virtual string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}
		
		private bool? activo;
		public virtual bool? Activo
		{
			get
			{
				return this.activo;
			}
			set
			{
				this.activo = value;
			}
		}
		
		private IList<Cursada> cursadas = new List<Cursada>();
		public virtual IList<Cursada> Cursadas
		{
			get
			{
				return this.cursadas;
			}
		}
		
		private IList<ConceptoXCurso> conceptoXCursos = new List<ConceptoXCurso>();
		public virtual IList<ConceptoXCurso> ConceptoXCursos
		{
			get
			{
				return this.conceptoXCursos;
			}
		}
		
	}
}
#pragma warning restore 1591
