using System;
using System.Collections.Generic;

namespace Bounds.Conexiones {

	public class ConexionEncontrarOponentes : ConexionBase<ConexionEncontrarOponentes.Entrada, ConexionEncontrarOponentes.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/encontrar-oponente";
		private readonly string nombre;

		public ConexionEncontrarOponentes(string nombre) : base(METODO, SERVICIO) {
			this.nombre = nombre;
		}

		protected override Entrada GenerarEntrada() {
			return new Entrada {
				nombreJugador = nombre
			};
		}

		[Serializable]
		public class Salida {
			public int vacio;
			public string nombreMazo;
			public string avatar;
			public string nombre;
			public List<string> cartas;
		}

		[Serializable]
		public class Entrada {
			public string nombreJugador;
		}

	}

}