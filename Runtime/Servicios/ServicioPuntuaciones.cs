using System;
using System.Collections.Generic;

namespace Bounds.Conexiones.Servicios {

	public class ServicioPuntuaciones : ServicioBounds<ServicioPuntuaciones.Entrada, ServicioPuntuaciones.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/puntuaciones";

		public ServicioPuntuaciones(string nombre) : base(METODO, SERVICIO) {
			entrada = new Entrada {
				nombreJugador = nombre
			};
		}

		[Serializable]
		public class Salida {
			public string nombre;
			public string division;
			public int victorias;
			public int derrotas;
			public List<string> oponentes;
		}

		[Serializable]
		public class Entrada {
			public string nombreJugador;
		}

	}

}