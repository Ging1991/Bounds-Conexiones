using System;

namespace Bounds.Conexiones.Servicios {

	public class ServicioNombreDisponible : ServicioBounds<ServicioNombreDisponible.Entrada, ServicioNombreDisponible.Salida> {

		private static readonly string METODO = "POST";
		private static readonly string SERVICIO = "/api/nombre-disponible";

		public ServicioNombreDisponible(string nombre) : base(METODO, SERVICIO) {
			entrada = new Entrada {
				nombre = nombre
			};
		}

		[Serializable]
		public class Salida {
			public bool estaDisponible;
		}

		[Serializable]
		public class Entrada {
			public string nombre;
		}

	}

}