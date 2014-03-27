﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
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
	public partial class ModeloDominio : OpenAccessContext, IModeloDominioUnitOfWork
	{
		private static string connectionStringName = @"CuotaSystem_DesaConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public ModeloDominio()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public ModeloDominio(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDominio(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public ModeloDominio(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDominio(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Parentesco> Parentescos 
		{
			get
			{
				return this.GetAll<Parentesco>();
			}
		}
		
		public IQueryable<Grado> Grados 
		{
			get
			{
				return this.GetAll<Grado>();
			}
		}
		
		public IQueryable<Escuela> Escuelas 
		{
			get
			{
				return this.GetAll<Escuela>();
			}
		}
		
		public IQueryable<Curso> Cursos 
		{
			get
			{
				return this.GetAll<Curso>();
			}
		}
		
		public IQueryable<Cursada> Cursadas 
		{
			get
			{
				return this.GetAll<Cursada>();
			}
		}
		
		public IQueryable<AutorizadosXAlumno> AutorizadosXAlumnos 
		{
			get
			{
				return this.GetAll<AutorizadosXAlumno>();
			}
		}
		
		public IQueryable<Alumno> Alumnos 
		{
			get
			{
				return this.GetAll<Alumno>();
			}
		}
		
		public IQueryable<Autorizado> Autorizados 
		{
			get
			{
				return this.GetAll<Autorizado>();
			}
		}
		
		public IQueryable<GrupoFamiliarXAlumno> GrupoFamiliarXAlumnos 
		{
			get
			{
				return this.GetAll<GrupoFamiliarXAlumno>();
			}
		}
		
		public IQueryable<GrupoFamiliar> GrupoFamiliars 
		{
			get
			{
				return this.GetAll<GrupoFamiliar>();
			}
		}
		
		public IQueryable<TipoDeAlumno> TipoDeAlumnos 
		{
			get
			{
				return this.GetAll<TipoDeAlumno>();
			}
		}
		
		public IQueryable<Inscripcion> Inscripcions 
		{
			get
			{
				return this.GetAll<Inscripcion>();
			}
		}
		
		public IQueryable<Concepto> Conceptos 
		{
			get
			{
				return this.GetAll<Concepto>();
			}
		}
		
		public IQueryable<DetallePago> DetallePagos 
		{
			get
			{
				return this.GetAll<DetallePago>();
			}
		}
		
		public IQueryable<Pago> Pagos 
		{
			get
			{
				return this.GetAll<Pago>();
			}
		}
		
		public IQueryable<Me> Mes 
		{
			get
			{
				return this.GetAll<Me>();
			}
		}
		
		public IQueryable<Descuento> Descuentos 
		{
			get
			{
				return this.GetAll<Descuento>();
			}
		}
		
		public IQueryable<TipoDeConcepto> TipoDeConceptos 
		{
			get
			{
				return this.GetAll<TipoDeConcepto>();
			}
		}
		
		public IQueryable<InscripcionXConcepto> InscripcionXConceptos 
		{
			get
			{
				return this.GetAll<InscripcionXConcepto>();
			}
		}
		
		public IQueryable<ConceptoXCurso> ConceptoXCursos 
		{
			get
			{
				return this.GetAll<ConceptoXCurso>();
			}
		}
		
		public IEnumerable<ListaAutorizadosXAlumnoResultSet0> SP_ListaAutorizadosXAlumno()
		{
			int returnValue;
			return SP_ListaAutorizadosXAlumno(out returnValue);
		}
		
		public IEnumerable<ListaAutorizadosXAlumnoResultSet0> SP_ListaAutorizadosXAlumno(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<ListaAutorizadosXAlumnoResultSet0> queryResult = this.ExecuteQuery<ListaAutorizadosXAlumnoResultSet0>("[dbo].[ListaAutorizadosXAlumno]", CommandType.StoredProcedure, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ListaCursadasXCursoResultSet0> SP_ListaCursadasXCurso()
		{
			int returnValue;
			return SP_ListaCursadasXCurso(out returnValue);
		}
		
		public IEnumerable<ListaCursadasXCursoResultSet0> SP_ListaCursadasXCurso(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<ListaCursadasXCursoResultSet0> queryResult = this.ExecuteQuery<ListaCursadasXCursoResultSet0>("[dbo].[ListaCursadasXCurso]", CommandType.StoredProcedure, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ListaInscripcionesResultSet0> SP_ListaInscripciones(int? idAlumno)
		{
			int returnValue;
			return SP_ListaInscripciones(idAlumno, out returnValue);
		}
		
		public IEnumerable<ListaInscripcionesResultSet0> SP_ListaInscripciones(int? idAlumno, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdAlumno = new OAParameter();
			parameterIdAlumno.ParameterName = "idAlumno";
			if(idAlumno.HasValue)
			{
				parameterIdAlumno.Value = idAlumno.Value;
			}
			else
			{
				parameterIdAlumno.DbType = DbType.Int32;
				parameterIdAlumno.Value = DBNull.Value;
			}

			IEnumerable<ListaInscripcionesResultSet0> queryResult = this.ExecuteQuery<ListaInscripcionesResultSet0>("[dbo].[ListaInscripciones]", CommandType.StoredProcedure, parameterIdAlumno, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> SP_DevuelveUltimoDetallePagoXAlumno(int? idAlumno, int? idConcepto)
		{
			int returnValue;
			return SP_DevuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto, out returnValue);
		}
		
		public IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> SP_DevuelveUltimoDetallePagoXAlumno(int? idAlumno, int? idConcepto, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdAlumno = new OAParameter();
			parameterIdAlumno.ParameterName = "idAlumno";
			if(idAlumno.HasValue)
			{
				parameterIdAlumno.Value = idAlumno.Value;
			}
			else
			{
				parameterIdAlumno.DbType = DbType.Int32;
				parameterIdAlumno.Value = DBNull.Value;
			}

			OAParameter parameterIdConcepto = new OAParameter();
			parameterIdConcepto.ParameterName = "idConcepto";
			if(idConcepto.HasValue)
			{
				parameterIdConcepto.Value = idConcepto.Value;
			}
			else
			{
				parameterIdConcepto.DbType = DbType.Int32;
				parameterIdConcepto.Value = DBNull.Value;
			}

			IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> queryResult = this.ExecuteQuery<DevuelveUltimoDetallePagoXAlumnoResultSet0>("[dbo].[DevuelveUltimoDetallePagoXAlumno]", CommandType.StoredProcedure, parameterIdAlumno, parameterIdConcepto, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ConceptoXAlumnoResultSet0> SP_ConceptoXAlumno(int? idAlumno, int? idTipoDeConcepto)
		{
			int returnValue;
			return SP_ConceptoXAlumno(idAlumno, idTipoDeConcepto, out returnValue);
		}
		
		public IEnumerable<ConceptoXAlumnoResultSet0> SP_ConceptoXAlumno(int? idAlumno, int? idTipoDeConcepto, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdAlumno = new OAParameter();
			parameterIdAlumno.ParameterName = "idAlumno";
			if(idAlumno.HasValue)
			{
				parameterIdAlumno.Value = idAlumno.Value;
			}
			else
			{
				parameterIdAlumno.DbType = DbType.Int32;
				parameterIdAlumno.Value = DBNull.Value;
			}

			OAParameter parameterIdTipoDeConcepto = new OAParameter();
			parameterIdTipoDeConcepto.ParameterName = "idTipoDeConcepto";
			if(idTipoDeConcepto.HasValue)
			{
				parameterIdTipoDeConcepto.Value = idTipoDeConcepto.Value;
			}
			else
			{
				parameterIdTipoDeConcepto.DbType = DbType.Int32;
				parameterIdTipoDeConcepto.Value = DBNull.Value;
			}

			IEnumerable<ConceptoXAlumnoResultSet0> queryResult = this.ExecuteQuery<ConceptoXAlumnoResultSet0>("[dbo].[ConceptoXAlumno]", CommandType.StoredProcedure, parameterIdAlumno, parameterIdTipoDeConcepto, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<DevuelveConceptoXCursoResultSet0> SP_DevuelveConceptoXCurso(int? idCurso)
		{
			int returnValue;
			return SP_DevuelveConceptoXCurso(idCurso, out returnValue);
		}
		
		public IEnumerable<DevuelveConceptoXCursoResultSet0> SP_DevuelveConceptoXCurso(int? idCurso, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdCurso = new OAParameter();
			parameterIdCurso.ParameterName = "idCurso";
			if(idCurso.HasValue)
			{
				parameterIdCurso.Value = idCurso.Value;
			}
			else
			{
				parameterIdCurso.DbType = DbType.Int32;
				parameterIdCurso.Value = DBNull.Value;
			}

			IEnumerable<DevuelveConceptoXCursoResultSet0> queryResult = this.ExecuteQuery<DevuelveConceptoXCursoResultSet0>("[dbo].[DevuelveConceptoXCurso]", CommandType.StoredProcedure, parameterIdCurso, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ReporteDePagosMensualesResultSet0> SP_ReporteDePagosMensuales()
		{
			int returnValue;
			return SP_ReporteDePagosMensuales(out returnValue);
		}
		
		public IEnumerable<ReporteDePagosMensualesResultSet0> SP_ReporteDePagosMensuales(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<ReporteDePagosMensualesResultSet0> queryResult = this.ExecuteQuery<ReporteDePagosMensualesResultSet0>("[dbo].[ReporteDePagosMensuales]", CommandType.StoredProcedure, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ReportePagosResultSet0> SP_ReportePagos(DateTime? fechaDesde, DateTime? fechaHasta)
		{
			int returnValue;
			return SP_ReportePagos(fechaDesde, fechaHasta, out returnValue);
		}
		
		public IEnumerable<ReportePagosResultSet0> SP_ReportePagos(DateTime? fechaDesde, DateTime? fechaHasta, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterFechaDesde = new OAParameter();
			parameterFechaDesde.ParameterName = "fechaDesde";
			if(fechaDesde.HasValue)
			{
				parameterFechaDesde.Value = fechaDesde.Value;
			}
			else
			{
				parameterFechaDesde.DbType = DbType.DateTime;
				parameterFechaDesde.Value = DBNull.Value;
			}

			OAParameter parameterFechaHasta = new OAParameter();
			parameterFechaHasta.ParameterName = "fechaHasta";
			if(fechaHasta.HasValue)
			{
				parameterFechaHasta.Value = fechaHasta.Value;
			}
			else
			{
				parameterFechaHasta.DbType = DbType.DateTime;
				parameterFechaHasta.Value = DBNull.Value;
			}

			IEnumerable<ReportePagosResultSet0> queryResult = this.ExecuteQuery<ReportePagosResultSet0>("[dbo].[ReportePagos]", CommandType.StoredProcedure, parameterFechaDesde, parameterFechaHasta, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<ListaHermanosResultSet0> SP_ListaHermanos(int? idGrupoFamiliar)
		{
			int returnValue;
			return SP_ListaHermanos(idGrupoFamiliar, out returnValue);
		}
		
		public IEnumerable<ListaHermanosResultSet0> SP_ListaHermanos(int? idGrupoFamiliar, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdGrupoFamiliar = new OAParameter();
			parameterIdGrupoFamiliar.ParameterName = "idGrupoFamiliar";
			if(idGrupoFamiliar.HasValue)
			{
				parameterIdGrupoFamiliar.Value = idGrupoFamiliar.Value;
			}
			else
			{
				parameterIdGrupoFamiliar.DbType = DbType.Int32;
				parameterIdGrupoFamiliar.Value = DBNull.Value;
			}

			IEnumerable<ListaHermanosResultSet0> queryResult = this.ExecuteQuery<ListaHermanosResultSet0>("[dbo].[ListaHermanos]", CommandType.StoredProcedure, parameterIdGrupoFamiliar, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
			backend.Logging.MetricStoreSnapshotInterval = 0;
			backend.ConnectionPool.MaxActive = 60;
			backend.ConnectionPool.Integrated.MaxIdle = 60;
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of ModeloDominio.
		/// </summary>
		/// <param name="config">The BackendConfiguration of ModeloDominio.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IModeloDominioUnitOfWork : IUnitOfWork
	{
		IQueryable<Parentesco> Parentescos
		{
			get;
		}
		IQueryable<Grado> Grados
		{
			get;
		}
		IQueryable<Escuela> Escuelas
		{
			get;
		}
		IQueryable<Curso> Cursos
		{
			get;
		}
		IQueryable<Cursada> Cursadas
		{
			get;
		}
		IQueryable<AutorizadosXAlumno> AutorizadosXAlumnos
		{
			get;
		}
		IQueryable<Alumno> Alumnos
		{
			get;
		}
		IQueryable<Autorizado> Autorizados
		{
			get;
		}
		IQueryable<GrupoFamiliarXAlumno> GrupoFamiliarXAlumnos
		{
			get;
		}
		IQueryable<GrupoFamiliar> GrupoFamiliars
		{
			get;
		}
		IQueryable<TipoDeAlumno> TipoDeAlumnos
		{
			get;
		}
		IQueryable<Inscripcion> Inscripcions
		{
			get;
		}
		IQueryable<Concepto> Conceptos
		{
			get;
		}
		IQueryable<DetallePago> DetallePagos
		{
			get;
		}
		IQueryable<Pago> Pagos
		{
			get;
		}
		IQueryable<Me> Mes
		{
			get;
		}
		IQueryable<Descuento> Descuentos
		{
			get;
		}
		IQueryable<TipoDeConcepto> TipoDeConceptos
		{
			get;
		}
		IQueryable<InscripcionXConcepto> InscripcionXConceptos
		{
			get;
		}
		IQueryable<ConceptoXCurso> ConceptoXCursos
		{
			get;
		}
		IEnumerable<ListaAutorizadosXAlumnoResultSet0> SP_ListaAutorizadosXAlumno();
		IEnumerable<ListaAutorizadosXAlumnoResultSet0> SP_ListaAutorizadosXAlumno(out int returnValue);
		IEnumerable<ListaCursadasXCursoResultSet0> SP_ListaCursadasXCurso();
		IEnumerable<ListaCursadasXCursoResultSet0> SP_ListaCursadasXCurso(out int returnValue);
		IEnumerable<ListaInscripcionesResultSet0> SP_ListaInscripciones(int? idAlumno);
		IEnumerable<ListaInscripcionesResultSet0> SP_ListaInscripciones(int? idAlumno, out int returnValue);
		IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> SP_DevuelveUltimoDetallePagoXAlumno(int? idAlumno, int? idConcepto);
		IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> SP_DevuelveUltimoDetallePagoXAlumno(int? idAlumno, int? idConcepto, out int returnValue);
		IEnumerable<ConceptoXAlumnoResultSet0> SP_ConceptoXAlumno(int? idAlumno, int? idTipoDeConcepto);
		IEnumerable<ConceptoXAlumnoResultSet0> SP_ConceptoXAlumno(int? idAlumno, int? idTipoDeConcepto, out int returnValue);
		IEnumerable<DevuelveConceptoXCursoResultSet0> SP_DevuelveConceptoXCurso(int? idCurso);
		IEnumerable<DevuelveConceptoXCursoResultSet0> SP_DevuelveConceptoXCurso(int? idCurso, out int returnValue);
		IEnumerable<ReporteDePagosMensualesResultSet0> SP_ReporteDePagosMensuales();
		IEnumerable<ReporteDePagosMensualesResultSet0> SP_ReporteDePagosMensuales(out int returnValue);
		IEnumerable<ReportePagosResultSet0> SP_ReportePagos(DateTime? fechaDesde, DateTime? fechaHasta);
		IEnumerable<ReportePagosResultSet0> SP_ReportePagos(DateTime? fechaDesde, DateTime? fechaHasta, out int returnValue);
		IEnumerable<ListaHermanosResultSet0> SP_ListaHermanos(int? idGrupoFamiliar);
		IEnumerable<ListaHermanosResultSet0> SP_ListaHermanos(int? idGrupoFamiliar, out int returnValue);
	}
}
#pragma warning restore 1591
