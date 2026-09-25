using System;
using System.Collections.Generic;

namespace Bounds.Conexiones.Servicios {

	public class ServicioRestricciones : ServicioBounds<ServicioRestricciones.Entrada, ServicioRestricciones.Salida> {

		private static readonly string METODO = "GET";
		private static readonly string SERVICIO = "/api/restricciones";

		public ServicioRestricciones() : base(METODO, SERVICIO) { }


		[Serializable]
		public class Salida {
			public List<int> prohibidas;
			public List<int> limitadas;
			public List<int> semilimitadas;
			public List<int> restringidas;
			public List<int> semirestringidas;
		}

		[Serializable]
		public class Entrada { }

	}

}