using System;
using System.Collections.Generic;

namespace Bounds.Conexiones {

	public class ConexionPuntuaciones : ConexionBase<ConexionPuntuaciones.Entrada, ConexionPuntuaciones.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/puntuaciones";
		private readonly string nombre;

		public ConexionPuntuaciones(string nombre) : base(METODO, SERVICIO) {
			this.nombre = nombre;
		}

		protected override Entrada GenerarEntrada() {
			return new Entrada {
				nombreJugador = nombre
			};
		}

		[System.Serializable]
		public class Salida {
			public int derrotas;
			public int victorias;
			public string nombre;
			public string division;
			public List<string> oponentes;
		}

		[Serializable]
		public class Entrada {
			public string nombreJugador;
		}

	}

}