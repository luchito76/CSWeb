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
	public partial class Escuela
	{
		private int idEscuela;
		public virtual int IdEscuela
		{
			get
			{
				return this.idEscuela;
			}
			set
			{
				this.idEscuela = value;
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
		
		private IList<Alumno> alumnos = new List<Alumno>();
		public virtual IList<Alumno> Alumnos
		{
			get
			{
				return this.alumnos;
			}
		}
		
	}
}
#pragma warning restore 1591
