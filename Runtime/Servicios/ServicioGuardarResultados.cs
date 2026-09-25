using System;
using System.Collections.Generic;

namespace Bounds.Conexiones.Servicios {

	public class ServicioGuardarResultados : ServicioBounds<ServicioGuardarResultados.Entrada, ServicioGuardarResultados.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/guardar-resultado";

		public ServicioGuardarResultados(
				string jugadorGanador, string jugadorPerdedor,
				List<int> cartasGanadoras, List<int> cartasPerdedoras) : base(METODO, SERVICIO) {

			entrada = new Entrada {
				jugadorGanador = jugadorGanador,
				jugadorPerdedor = jugadorPerdedor,
				cartasGanadoras = cartasGanadoras,
				cartasPerdedoras = cartasPerdedoras
			};
		}

		[Serializable]
		public class Salida {
			public bool resultado;
		}

		[Serializable]
		public class Entrada {
			public string jugadorGanador;
			public string jugadorPerdedor;
			public List<int> cartasGanadoras;
			public List<int> cartasPerdedoras;
		}

	}

}