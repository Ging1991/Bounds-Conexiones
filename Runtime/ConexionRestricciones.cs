using System;
using System.Collections.Generic;

namespace Bounds.Conexiones {

	public class ConexionRestricciones : ConexionBase<ConexionRestricciones.Entrada, ConexionRestricciones.Salida> {

		private static readonly string METODO = "GET";
		private static readonly string SERVICIO = "/api/restricciones";

		public ConexionRestricciones() : base(METODO, SERVICIO) { }

		protected override Entrada GenerarEntrada() {
			return null;
		}

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