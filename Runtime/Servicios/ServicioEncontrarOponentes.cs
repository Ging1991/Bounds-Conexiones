using System;
using System.Collections.Generic;

namespace Bounds.Conexiones.Servicios {

	public class ServicioEncontrarOponentes : ServicioBounds<ServicioEncontrarOponentes.Entrada, ServicioEncontrarOponentes.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/encontrar-oponente";

		public ServicioEncontrarOponentes(string nombre) : base(METODO, SERVICIO) {
			entrada = new Entrada {
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