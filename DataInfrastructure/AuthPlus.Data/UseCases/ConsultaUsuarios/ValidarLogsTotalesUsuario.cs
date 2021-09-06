///////////////////////////////////////////////////////////
//  ValidarLogsTotalesUsuario.cs
//  Implementation of the Class ValidarLogsTotalesUsuario
//  Generated by Enterprise Architect
//  Created on:      05-sept.-2021 7:18:54 p. m.
//  Original author: Daniel
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Entities;
namespace ConsultaUsuarios {
	public class ValidarLogsTotalesUsuario {
		private Context.FakeDbContext FakeContext;


		public ValidarLogsTotalesUsuario(Context.FakeDbContext _FakeContext){
			FakeContext = _FakeContext;
		}

		~ValidarLogsTotalesUsuario(){

		}

		/// 
		/// <param name="User"></param>
		public List<Log> Response(Usuario User){
			return FakeContext.LogsList.FindAll(x => x.User.Id == User.Id);
		}

		/// 
		/// <param name="Usuario"></param>
		public void Validate(Usuario Usuario){
			if (Usuario.Equals(null)){
				throw new NullReferenceException();
			}
		}

	}//end ValidarLogsTotalesUsuario

}//end namespace ConsultaUsuarios